/*
Rules: E13-7-form-await
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: await new Ready();
Into: new Ready();
*/
using System;
using System.Runtime.CompilerServices;
struct Ready : INotifyCompletion
{
    public Ready GetAwaiter() { Program.trace = Program.trace * 10 + 1; return this; }
    public bool IsCompleted { get { return true; } }
    public int GetResult() { Program.trace = Program.trace * 10 + 2; return 37; }
    public void OnCompleted(Action continuation) { throw new Exception("ready-awaitable-suspended"); }
}
class Program
{
    public static int trace;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Body()
    {
        await new Ready();
        trace = trace * 10 + 3;
    }
    static void Main()
    {
        Body();
        Check(trace == 123, "await-statement-evaluates-and-discards-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
