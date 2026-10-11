/*
Rules: E8-3-8-decimal-nearest-rounding; E8-3-8-decimal-tie-even; E8-3-8-decimal-result-exactness
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unit * 5m / 2m
Into: unit * 7m / 2m
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
        decimal unit = 0.0000000000000000000000000001m;
        decimal lowerEven = unit * 5m / 2m; decimal upperEven = unit * 7m / 2m;
        Check(lowerEven == 2m * unit && upperEven == 4m * unit, "decimal-nearest-with-even-ties");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
