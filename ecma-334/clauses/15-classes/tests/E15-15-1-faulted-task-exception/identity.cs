/*
Rules: E15-15-1-faulted-task-exception; E15-15-1-task-state-set
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: run
Stdout: OK 3
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
        Task<int> task = Read();
        Check(task.IsCompleted && task.IsFaulted, "task-state-is-faulted-after-uncaught-exception");
        Fault caught = null;
        try { task.GetAwaiter().GetResult(); }
        catch (Fault ex) { caught = ex; }
        catch (Exception) { }
        Check(caught == Failure, "faulted-task-records-pertinent-exception-identity");
        Check(task.IsCompleted && task.IsFaulted, "observing-exception-retains-faulted-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
