/*
Rules: E9-4-4-8-false-state-end-transfer
Authority: ECMA-334 7th ed 9.4.4.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: gate || (cell = 39) < 0
Into: gate && (cell = 39) < 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool gate = true;
        int cell;
        while (gate || (cell = 39) < 0) gate = false;
        Check(cell == 39, "false-substate-at-loop-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
