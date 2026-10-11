/*
Rules: E8-3-8-decimal-preserve-scale
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left + right
Into: left * right
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
        decimal left = 1.20m; decimal right = 1.30m; decimal sum = left + right;
        int[] bits = decimal.GetBits(sum);
        Check(sum == 2.50m && ((bits[3] >> 16) & 255) == 2, "addition-preserves-maximum-operand-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
