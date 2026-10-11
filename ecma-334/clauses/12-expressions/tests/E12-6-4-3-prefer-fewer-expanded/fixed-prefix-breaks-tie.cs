/*
Rules: E12-6-4-3-prefer-fewer-expanded
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(3, 5, 7)
Into: Pick()
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(int first, params int[] tail) { return 1; }
    static int Pick(params int[] all) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(3, 5, 7) == 1, "two-expanded-elements-better-than-three");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
