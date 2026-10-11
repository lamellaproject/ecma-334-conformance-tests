/*
Rules: E12-10-3-decimal-result-scale; E12-10-3-decimal-preferred-scale; E12-10-3-decimal-predefined; E12-10-3-decimal-equivalence
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: System.Decimal r = x / y;
Into: System.Decimal r = x * y;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Scale(decimal x) { return (Decimal.GetBits(x)[3] >> 16) & 255; }
    static void Main()
    {
        decimal x = 6.00M, y = 2.0M; System.Decimal r = x / y;
        Check(r == 3.0M && Scale(r) == 1, "preferred-scale-is-difference");
        x = 1.0M; y = 8.00M; r = x / y;
        Check(r == 0.125M && Scale(r) == 3, "closest-exact-scale");
        Check(r == Decimal.Divide(x, y), "decimal-operation-equivalence");
        x = 100M; y = 2.00M; r = x / y;
        Check(r == 50M && Scale(r) == 0, "negative-preferred-scale");
        x = -6.00M; y = 4.0M; r = x / y;
        Check(r == -1.5M && Scale(r) == 1, "negative-exact-quotient");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
