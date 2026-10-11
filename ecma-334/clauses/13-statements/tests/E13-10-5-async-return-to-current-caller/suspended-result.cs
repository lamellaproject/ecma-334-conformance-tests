/*
Rules: E13-10-5-async-return-to-current-caller; E13-10-5-async-result-recorded
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return 47;
Into: return 48;
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static async Task<int> Produce(Task<int> gate)
    {
        try { trace = trace * 10 + 1; await gate; trace = trace * 10 + 3; return 47; }
        finally { trace = trace * 10 + 4; }
    }
    static void Main()
    {
        var gate = new TaskCompletionSource<int>();
        Task<int> result = Produce(gate.Task);
        Check(!result.IsCompleted && trace == 1, "async-suspends-to-original-caller");
        trace = trace * 10 + 2;
        gate.SetResult(0);
        int actual = result.GetAwaiter().GetResult();
        Check(actual == 47 && result.IsCompleted && !result.IsFaulted, "async-return-result-recorded");
        Check(trace == 1234, "async-return-finally-before-task-completion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
