/*
Rules: E9-4-4-10-omitted-condition-true; E9-4-4-11-break-state-transfer
Authority: ECMA-334 7th ed 9.4.4.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: for (;;)
Into: for (; gate;)
*/
using System;
class Program
{
    static int checks, failures;
    static bool gate;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        for (;;) { cell = 77; break; }
        Check(cell == 77, "only-loop-exit-is-assigned-break");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
