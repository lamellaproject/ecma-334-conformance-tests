/*
Rules: E9-4-4-23-last-subexpression-exit; E9-4-4-23-embedded-expression-scope
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: await new Ready(cell = 41)
Into: await new Ready(41)
*/
using System;
using System.Runtime.CompilerServices;
struct Ready : INotifyCompletion
{
    int value;
    public Ready(int value) { this.value = value; }
    public Ready GetAwaiter() { return this; }
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action action) { action(); }
    public int GetResult() { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Probe()
    {
        int cell;
        int result = await new Ready(cell = 41);
        Check(result == 41 && cell == 41, "await-operand-state-reaches-exit");
    }
    static void Main()
    {
        Probe();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
