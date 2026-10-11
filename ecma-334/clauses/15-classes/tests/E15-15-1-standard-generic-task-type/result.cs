/*
Rules: E15-15-1-standard-generic-task-type; E15-15-1-successful-task-result; E15-15-1-task-awaitable; E15-15-1-task-await-operand
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return await Task.FromResult(item);
Into: return await Task.FromResult(new Marker());
*/
using System;
using System.Threading.Tasks;
class Marker { }
class Program
{
    static int checks, failures;
    static async Task<Marker> Read(Marker item) { return await Task.FromResult(item); }
    static async Task<Marker> Consume(Task<Marker> task) { return await task; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        Task<Marker> task = Read(item);
        Check(task != null && task.IsCompleted && !task.IsFaulted, "generic-task-succeeds");
        Check(task.GetAwaiter().GetResult() == item, "succeeded-task-records-typed-result-identity");
        Check(Consume(task).GetAwaiter().GetResult() == item, "generic-task-is-await-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
