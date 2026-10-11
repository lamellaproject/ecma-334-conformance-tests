/*
Rules: E12-6-4-3-comparison-optional
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(3)
Into: Pick(3L)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(int x, long unused = 0) { return 1; }
    static int Pick(long x, int unused = 0) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(3) == 1, "omitted-optional-types-do-not-enter-conversion-comparison");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
