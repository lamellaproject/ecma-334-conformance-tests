/*
Rules: E15-15-1-standard-task-type; E15-15-1-async-method-classification; E15-15-1-task-returning-classification
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: async Task Work()
Into: Task Work()
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static async Task Work() { Trace += "S"; await Task.FromResult(13); Trace += "E"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Task task = Work();
        Check(task != null, "async-method-returns-standard-task");
        task.GetAwaiter().GetResult();
        Check(Trace == "SE", "standard-task-body-evaluated-in-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
