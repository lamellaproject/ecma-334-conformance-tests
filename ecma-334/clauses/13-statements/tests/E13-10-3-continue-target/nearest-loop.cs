/*
Rules: E13-10-3-continue-target
Authority: ECMA-334 7th ed 13.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if (inner < 2) continue;
Into: if (inner < 2) break;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int visits = 0, ends = 0;
        for (int outer = 0; outer < 2; outer++)
        {
            for (int inner = 0; inner < 3; inner++) { visits++; if (inner < 2) continue; ends++; }
        }
        Check(visits == 6, "continue-applies-to-inner-loop");
        Check(ends == 2, "inner-body-tail-runs-only-on-last-iteration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
