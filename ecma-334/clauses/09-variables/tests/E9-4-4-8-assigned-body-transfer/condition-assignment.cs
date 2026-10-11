/*
Rules: E9-4-4-8-assigned-body-transfer; E9-4-4-8-assigned-end-transfer; E9-4-4-8-condition-entry
Authority: ECMA-334 7th ed 9.4.4.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: while ((cell = Next()) > 0)
Into: while (Next() > 0)
*/
using System;
class Program
{
    static int checks, failures, sequence = 2;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next() { return sequence--; }
    static void Main()
    {
        int cell;
        int expected = 2;
        while ((cell = Next()) > 0)
        {
            Check(cell == expected, "condition-assigns-body");
            expected--;
        }
        Check(cell == 0 && expected == 0, "condition-assigns-loop-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
