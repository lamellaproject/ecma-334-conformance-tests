/*
Rules: E15-15-4-async-void-exception-context; E15-15-4-async-void-uncaught-notification
Authority: ECMA-334 7th ed 15.15.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: async void Work()
Into: async Task Work()
*/
using System;
using System.Threading;
using System.Threading.Tasks;
class Journal : SynchronizationContext
{
    public int Starts, Ends, Posts;
    public SendOrPostCallback Pending;
    public object PendingState;
    public override void OperationStarted() { Starts++; }
    public override void OperationCompleted() { Ends++; }
    public override void Post(SendOrPostCallback callback, object state) { Posts++; Pending = callback; PendingState = state; }
}
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static Journal Context;
    static Fault Failure = new Fault();
    static string Trace = "";
    static async void Work() { Trace += "B"; await Task.FromResult(0); Trace += "E"; throw Failure; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        SynchronizationContext previous = SynchronizationContext.Current;
        Context = new Journal();
        SynchronizationContext.SetSynchronizationContext(Context);
        try
        {
            bool escaped = false;
            try { Work(); } catch (Exception) { escaped = true; }
            Check(!escaped && Trace == "BE", "unsuspended-void-body-exception-returns-control-to-original-caller");
            Check(Context.Starts > 0, "faulting-void-body-notifies-context-of-start");
            Check(Context.Posts > 0 && Context.Pending != null, "unsuspended-uncaught-exception-is-delivered-through-context");
            Fault caught = null;
            try { if (Context.Pending != null) Context.Pending(Context.PendingState); }
            catch (Fault ex) { caught = ex; }
            catch (Exception) { }
            Check(caught == Failure, "unsuspended-void-exception-delivery-preserves-identity");
            Check(Context.Ends > 0, "context-observes-faulting-void-operation-end");
        }
        finally { SynchronizationContext.SetSynchronizationContext(previous); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
