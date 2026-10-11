/*
Rules: E12-6-4-3-comparison-reorder
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(wide: 5, small: 3)
Into: Pick(wide: 5, small: 3L)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(int small, long wide) { return 1; }
    static int Pick(long wide, long small) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(wide: 5, small: 3) == 1, "parameters-reordered-to-matching-named-arguments-before-comparison");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
