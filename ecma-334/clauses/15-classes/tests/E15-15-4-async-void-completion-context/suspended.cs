/*
Rules: E15-15-4-async-void-completion-context; E15-15-4-async-void-start-notification; E15-15-4-async-void-success-notification
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
    public int Starts, Ends;
    public bool CompletionAfterBody;
    public override void OperationStarted() { Starts++; }
    public override void OperationCompleted() { Ends++; CompletionAfterBody = Program.Trace == "BGE"; }
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
class Program
{
    static int checks, failures;
    static Journal Context;
    public static string Trace = "";
    static async void Work() { Trace += "B"; await new Gate(); Trace += "E"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        SynchronizationContext previous = SynchronizationContext.Current;
        Context = new Journal();
        SynchronizationContext.SetSynchronizationContext(Context);
        try
        {
            Work();
            Check(Context.Starts > 0 && Context.Ends == 0, "suspended-void-invocation-has-start-without-completion-notification");
            Check(Trace == "B" && Gate.Resume != null, "void-invocation-returns-control-at-incomplete-await");
            Gate.Ready = true;
            if (Gate.Resume != null) Gate.Resume();
            Check(Trace == "BGE", "void-body-resumes-after-awaited-getresult");
            Check(Context.Ends > 0, "resumed-void-body-notifies-context-of-success");
            Check(Context.CompletionAfterBody, "resumed-success-notification-follows-body-end");
        }
        finally { SynchronizationContext.SetSynchronizationContext(previous); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
