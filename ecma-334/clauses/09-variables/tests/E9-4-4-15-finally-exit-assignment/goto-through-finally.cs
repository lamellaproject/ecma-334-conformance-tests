/*
Rules: E9-4-4-15-finally-exit-assignment
Authority: ECMA-334 7th ed 9.4.4.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finally { cell = 87; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        try { goto Done; }
        finally { cell = 87; }
        Done: Check(cell == 87, "finally-assigns-on-goto-transfer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
