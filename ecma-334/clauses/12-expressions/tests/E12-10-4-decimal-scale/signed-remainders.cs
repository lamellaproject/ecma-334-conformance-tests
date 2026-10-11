/*
Rules: E12-10-4-decimal-scale; E12-10-4-decimal-sign; E12-10-4-decimal-predefined; E12-10-4-decimal-equivalence; E12-10-4-decimal-no-exception
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: System.Decimal r = x % y;
Into: System.Decimal r = x / y;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Scale(decimal x) { return (Decimal.GetBits(x)[3] >> 16) & 255; }
    static void Main()
    {
        decimal x = 12.30M, y = 5.0M; decimal quotient = x / y; System.Decimal r = x % y;
        Check(quotient == 2.46M && r == 2.30M && Scale(r) == 2, "dividend-larger-scale");
        Check(r == Decimal.Remainder(x, y), "decimal-operation-equivalence");
        x = -12.30M; r = x % y; Check(r == -2.30M && Scale(r) == 2, "negative-dividend");
        y = -5.0M; r = x % y; Check(r == -2.30M, "divisor-does-not-set-sign");
        x = 1.2M; y = 0.007M; quotient = x / y; r = x % y;
        Check(quotient > 171M && r == 0.003M && Scale(r) == 3, "divisor-larger-scale-no-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
