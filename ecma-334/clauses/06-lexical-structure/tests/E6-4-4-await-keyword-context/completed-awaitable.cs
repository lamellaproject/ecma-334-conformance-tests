/*
Rules: E6-4-4-await-keyword-context; E6-4-4-grammar-contextual-keyword-4; E6-4-4-grammar-contextual-keyword-5
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = await new Ready();
Into: int result = new Ready();
*/
using System;
using System.Runtime.CompilerServices;
struct Ready : INotifyCompletion
{
    public Ready GetAwaiter() { return this; }
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action continuation) { continuation(); }
    public int GetResult() { return 61; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Sample()
    {
        int result = await new Ready();
        Check(result == 61, "await-is-a-keyword-in-async-method");
    }
    static void Main()
    {
        Sample();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
