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
using System.Runtime.CompilerServices;
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
struct Gate : INotifyCompletion
{
    public static bool Ready;
    public static Action Resume;
    public Gate GetAwaiter() { return this; }
    public bool IsCompleted { get { return Ready; } }
    public void OnCompleted(Action action) { Resume = action; }
    public void GetResult() { Program.Trace += "G"; }
}
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static Journal Context;
    static Fault Failure = new Fault();
    public static string Trace = "";
    static async void Work() { Trace += "B"; await new Gate(); Trace += "E"; throw Failure; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        SynchronizationContext previous = SynchronizationContext.Current;
        Context = new Journal();
        SynchronizationContext.SetSynchronizationContext(Context);
        try
        {
            Work();
            Check(Context.Starts > 0 && Context.Ends == 0 && Context.Posts == 0, "exception-notification-is-pending-before-void-body-resumption");
            Gate.Ready = true;
            bool escaped = false;
            try { if (Gate.Resume != null) Gate.Resume(); } catch (Exception) { escaped = true; }
            Check(!escaped && Trace == "BGE", "void-body-exception-is-routed-through-context-instead-of-resumer");
            Check(Context.Posts > 0 && Context.Pending != null, "context-is-notified-with-exception-delivery-callback");
            Fault caught = null;
            // Process the context's queued callback directly; no background thread or timing is required.
            try { if (Context.Pending != null) Context.Pending(Context.PendingState); }
            catch (Fault ex) { caught = ex; }
            catch (Exception) { }
            Check(caught == Failure, "context-receives-original-uncaught-exception-identity");
            Check(Context.Ends > 0, "faulting-void-operation-notifies-context-that-it-ended");
        }
        finally { SynchronizationContext.SetSynchronizationContext(previous); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
