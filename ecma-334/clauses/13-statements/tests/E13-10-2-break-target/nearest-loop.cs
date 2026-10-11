/*
Rules: E13-10-2-break-target; E13-1-embedded-jump; E13-10-2-form-break; E13-10-1-form-break-jump; E13-10-1-jump-unconditional-control; E13-10-1-jump-target-definition; E13-10-1-jump-direct-transfer
Authority: ECMA-334 7th ed 13.10.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: break;
Into: continue;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int visits = 0;
        for (int outer = 0; outer < 2; outer++)
        {
            for (int inner = 0; inner < 3; inner++) { visits++; if (true) break; }
        }
        Check(visits == 2, "break-exits-only-inner-loop");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
