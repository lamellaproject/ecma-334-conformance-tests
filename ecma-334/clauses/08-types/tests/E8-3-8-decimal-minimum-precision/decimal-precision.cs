/*
Rules: E8-3-8-decimal-minimum-precision; E8-3-8-decimal-fractional-exactness; E8-3-8-decimal-large-exactness; E8-3-8-decimal-greater-precision; E8-3-8-decimal-to-floating-precision-loss
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal wide = 1000000000000000000000000001m;
Into: decimal wide = 1000000000000000000000000000m;
*/
using System;
// 8.3.8, p. 79: this test uses decimal precision, as corrected in types.md,
// 8.3.8 at dotnet/csharpstandard commit 6460eafbf957c24565c0ba099f6077e8c701e3c9.
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal wide = 1000000000000000000000000001m;
        decimal tiny = 0.0000000000000000000000000001m;
        decimal roundTrip = (decimal)(double)wide;
        Check(wide - 1000000000000000000000000000m == 1m && tiny * 10000000000000000000000000000m == 1m && wide != roundTrip, "decimal-precision-beyond-binary-double");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
