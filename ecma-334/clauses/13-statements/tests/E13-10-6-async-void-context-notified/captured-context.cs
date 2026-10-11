/*
Rules: E13-10-6-async-void-context-notified
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: throw expected;
Into: return;
*/
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Exception expected = new Exception();
    class Context : SynchronizationContext
    {
        public SendOrPostCallback callback;
        public object state;
        public int posts, started, completed;
        public override void OperationStarted() { started++; }
        public override void OperationCompleted() { completed++; }
        public override void Post(SendOrPostCallback action, object value) { posts++; callback = action; state = value; }
    }
    static async void Raise() { await Task.FromResult(0); throw expected; }
    static void Main()
    {
        SynchronizationContext previous = SynchronizationContext.Current;
        Context context = new Context();
        Exception observed = null;
        bool escapedCall = false;
        try
        {
            SynchronizationContext.SetSynchronizationContext(context);
            try { Raise(); }
            catch (Exception) { escapedCall = true; }
            if (context.callback != null)
            {
                try { context.callback(context.state); }
                catch (Exception actual) { observed = actual; }
            }
        }
        finally { SynchronizationContext.SetSynchronizationContext(previous); }
        Check(!escapedCall && context.posts == 1, "async-void-notifies-captured-context");
        Check(observed == expected, "context-notified-of-original-exception");
        Check(context.started == 1 && context.completed == 1, "context-lifetime-notifications");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
