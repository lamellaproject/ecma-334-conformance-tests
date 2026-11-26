/*
Rules: E12-10-2-decimal-scale; E12-10-2-decimal-predefined
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"target_requires":["decimal-96-scale-28"]}
Mutate: x * y
Into: x + y
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Scale(decimal x) { return (Decimal.GetBits(x)[3] >> 16) & 255; }
    static void Main()
    {
        decimal x = 1.20M, y = 3.0M; System.Decimal result = x * y;
        Check(result == 3.600M, "product-value"); Check(Scale(result) == 3, "sum-of-scales");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
