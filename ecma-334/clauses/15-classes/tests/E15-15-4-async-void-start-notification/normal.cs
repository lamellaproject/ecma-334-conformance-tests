/*
Rules: E15-15-4-async-void-start-notification; E15-15-4-async-void-completion-context; E15-15-4-async-void-success-notification
Authority: ECMA-334 7th ed 15.15.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: async void Work()
Into: async Task Work()
*/
using System;
using System.Threading;
using System.Threading.Tasks;
class Journal : SynchronizationContext
{
    public int Starts, Ends;
    public bool CompletionAfterBody;
    public override void OperationStarted() { Starts++; }
    public override void OperationCompleted() { Ends++; CompletionAfterBody = Program.BodyEnded; }
}
class Program
{
    static int checks, failures;
    static Journal Context;
    static bool BodySawStart;
    public static bool BodyEnded;
    static async void Work()
    {
        BodySawStart = Context.Starts > 0;
        await Task.FromResult(0);
        BodyEnded = true;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        SynchronizationContext previous = SynchronizationContext.Current;
        Context = new Journal();
        SynchronizationContext.SetSynchronizationContext(Context);
        try
        {
            Work();
            Check(Context.Starts > 0, "async-void-notifies-current-context-of-start");
            Check(BodySawStart, "start-notification-precedes-body-evaluation");
            Check(Context.Ends > 0, "async-void-communicates-successful-completion-to-context");
            Check(Context.CompletionAfterBody, "success-notification-follows-normal-body-end");
        }
        finally { SynchronizationContext.SetSynchronizationContext(previous); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
