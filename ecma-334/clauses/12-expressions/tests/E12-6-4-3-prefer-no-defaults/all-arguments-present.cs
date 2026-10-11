/*
Rules: E12-6-4-3-prefer-no-defaults
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(3)
Into: Pick(3, extra: 5)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(int x) { return 1; }
    static int Pick(int x, int extra = 0) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(3) == 1, "supplied-all-parameters-preferred-over-needing-an-optional-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
