/*
Rules: E8-3-6-integral-operator-precision
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: short small = 30000;
Into: short small = 29999;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        short small = 30000; byte tiny = 240; uint unsigned = 4000000000U;
        int promoted = small + small; int product = tiny * tiny; long mixed = unsigned + small;
        Check(promoted == 60000 && product == 57600 && mixed == 4000030000L, "operators-use-promoted-precision");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
