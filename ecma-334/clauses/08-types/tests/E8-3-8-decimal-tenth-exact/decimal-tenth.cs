/*
Rules: E8-3-8-decimal-tenth-exact; E8-3-8-decimal-binary-promotion; E8-3-8-decimal-exact-then-round
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: tenth * 10
Into: tenth * 9
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
        decimal tenth = 0.1m;
        decimal result = tenth * 10;
        Check(result == 1m && tenth + tenth + tenth == 0.3m, "exact-decimal-fraction-and-integer-promotion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
