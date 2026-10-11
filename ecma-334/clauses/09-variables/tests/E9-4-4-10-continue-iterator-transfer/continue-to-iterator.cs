/*
Rules: E9-4-4-10-continue-iterator-transfer; E9-4-4-11-continue-state-transfer
Authority: ECMA-334 7th ed 9.4.4.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: cell = index + 30;
Into: ;
*/
using System;
class Program
{
    static int checks, failures, seen;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Observe(int cell) { Check(cell == seen + 30, "continue-assignment-reaches-iterator"); seen++; }
    static void Main()
    {
        int cell;
        for (int index = 0; index < 2; Observe(cell), index++)
        {
            cell = index + 30;
            continue;
        }
        Check(seen == 2, "iterator-runs-after-each-continue");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
