/*
Rules: E7-1-synthesized-task-int; E7-1-synthesized-parameters; E7-1-entry-async-task
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static async Task<int> Main()
Into: static async Task<long> Main()
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async Task<int> Main()
    {
        await Task.Delay(50);
        var entry = typeof(Program).Assembly.EntryPoint;
        Check(entry.ReturnType == typeof(int), "synthesized-integer-return");
        Check(entry.GetParameters().Length == 0, "synthesized-empty-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures;
    }
}
