/*
Rules: E13-10-3-continue-end-unreachable
Authority: ECMA-334 7th ed 13.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: continue;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int visits = 0;
        for (int step = 0; step < 2; step++) { continue; visits++; }
        Check(visits == 0, "statement-after-continue-unreachable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
