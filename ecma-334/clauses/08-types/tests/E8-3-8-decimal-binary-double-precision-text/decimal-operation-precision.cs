/*
Rules: E8-3-8-decimal-binary-double-precision-text; E8-3-8-decimal-exact-then-round
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal result = source + 1m;
Into: decimal result = (decimal)((double)source + 1d);
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
        decimal source = 10000000000000001m;
        decimal result = source + 1m;
        Check(result == 10000000000000002m, "decimal-operation-retains-precision-beyond-binary-double");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
