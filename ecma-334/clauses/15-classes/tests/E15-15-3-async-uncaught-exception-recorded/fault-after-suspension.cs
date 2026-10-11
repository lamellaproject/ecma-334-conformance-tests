/*
Rules: E15-15-3-async-uncaught-exception-recorded; E15-15-3-async-uncaught-task-faulted; E15-15-3-async-termination-leaves-incomplete; E15-15-3-async-return-control-and-task
Authority: ECMA-334 7th ed 15.15.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: throw Failure;
Into: return 13;
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
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static Fault Failure = new Fault();
    public static string Trace = "";
    static async Task<int> Read() { Trace += "S"; await new Gate(); Trace += "R"; throw Failure; }
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
        bool escaped = false;
        try { if (Gate.Resume != null) Gate.Resume(); } catch (Exception) { escaped = true; }
        Trace += "D";
        Check(!escaped && Trace == "ASBCGRD", "uncaught-body-exception-returns-control-to-resumption-caller");
        Check(task.IsCompleted && task.IsFaulted, "uncaught-resumed-exception-makes-task-faulted");
        Fault caught = null;
        try { if (task.IsCompleted) task.GetAwaiter().GetResult(); } catch (Fault ex) { caught = ex; } catch (Exception) { }
        Check(caught == Failure, "resumed-uncaught-exception-identity-is-recorded-in-return-task");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
