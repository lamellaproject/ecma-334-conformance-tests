/*
Rules: E15-15-1-async-await-suspension; E15-15-1-async-resumption-delegate; E15-15-1-resumption-delegate-action-type; E15-15-1-current-caller-original; E15-15-1-current-caller-resumer; E15-15-1-task-state-set
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: await new Gate();
Into: await Task.FromResult(0);
*/
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
    public static string Trace = "";
    static async Task<int> Read() { Trace += "S"; await new Gate(); Trace += "R"; return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Trace += "A";
        Task<int> task = Read();
        Trace += "B";
        Check(Trace == "ASB", "original-caller-regains-control-at-await");
        Check(!task.IsCompleted && Gate.Resume != null, "incomplete-task-has-action-resumption-delegate");
        Gate.Ready = true;
        Trace += "C";
        if (Gate.Resume != null) Gate.Resume();
        Trace += "D";
        Check(Trace == "ASBCGRD", "resumption-caller-executes-from-suspended-await");
        Check(task.IsCompleted && !task.IsFaulted, "manual-resumption-moves-task-to-succeeded-state");
        Check(task.IsCompleted && task.GetAwaiter().GetResult() == 13, "manual-resumption-preserves-task-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
