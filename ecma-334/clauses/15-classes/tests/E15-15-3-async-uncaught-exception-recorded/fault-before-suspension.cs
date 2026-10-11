/*
Rules: E15-15-3-async-uncaught-exception-recorded; E15-15-3-async-uncaught-task-faulted; E15-15-3-async-termination-leaves-incomplete; E15-15-3-async-return-control-and-task
Authority: ECMA-334 7th ed 15.15.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: throw Failure;
Into: return 13;
*/
using System;
using System.Threading.Tasks;
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static Fault Failure = new Fault();
    static async Task<int> Read() { await Task.FromResult(0); throw Failure; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Task<int> task = null;
        bool escaped = false;
        try { task = Read(); } catch (Exception) { escaped = true; }
        Check(!escaped && task != null, "uncaught-body-exception-returns-task-to-original-caller");
        Check(task != null && task.IsCompleted && task.IsFaulted, "exception-before-suspension-makes-return-task-faulted");
        Fault caught = null;
        try { if (task != null && task.IsCompleted) task.GetAwaiter().GetResult(); }
        catch (Fault ex) { caught = ex; }
        catch (Exception) { }
        Check(caught == Failure, "faulted-return-task-records-uncaught-exception-identity");
        Check(task != null && task.IsCompleted && task.IsFaulted, "observing-fault-does-not-return-task-to-incomplete-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
