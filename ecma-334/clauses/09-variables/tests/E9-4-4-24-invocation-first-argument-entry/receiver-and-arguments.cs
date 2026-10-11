/*
Rules: E9-4-4-24-invocation-first-argument-entry; E9-4-4-24-successive-argument-entry; E9-4-4-24-other-call-exit-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Factory(out cell)
Into: Factory(out _)
*/
using System;
class Receiver
{
    public int Read(int first, int second, int third) { return first * 10000 + second * 100 + third; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Receiver Factory(out int value) { value = 18; return new Receiver(); }
    static void Main()
    {
        int cell;
        int result = Factory(out cell).Read(cell, cell = 29, cell);
        Check(result == 182929, "receiver-then-arguments-left-to-right");
        Check(cell == 29, "last-argument-state-at-call-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
