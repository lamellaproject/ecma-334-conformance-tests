/*
Rules: E15-15-1-async-anonymous-function-classification
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: async () =>
Into: () =>
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<Task<int>> read = async () => { Calls++; return await Task.FromResult(13); };
        Check(read().GetAwaiter().GetResult() == 13, "async-lambda-task-result");
        Check(Calls == 1, "async-lambda-body-executed-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
