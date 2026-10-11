/*
Rules: E9-4-4-19-body-transfer
Authority: ECMA-334 7th ed 9.4.4.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Monitor(out cell)
Into: Monitor(out _)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static object Monitor(out int cell) { cell = 72; return new object(); }
    static void Main()
    {
        int cell;
        lock (Monitor(out cell)) Check(cell == 72, "lock-expression-assigns-body-entry");
        Check(cell == 72, "lock-exit-preserves-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
