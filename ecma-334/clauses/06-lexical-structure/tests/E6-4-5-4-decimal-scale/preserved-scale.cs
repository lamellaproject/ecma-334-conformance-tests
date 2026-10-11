/*
Rules: E6-4-5-4-decimal-scale
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: 12.3400m
Into: 12.34m
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Bits(decimal value, int coefficient, int scale)
    {
        int[] bits = decimal.GetBits(value);
        return bits[0] == coefficient && bits[1] == 0 && bits[2] == 0 && bits[3] == scale * 65536;
    }
    static void Main()
    {
        Check(Bits(12.3400m, 123400, 4), "trailing-zeros");
        Check(Bits(6400e-3m, 6400, 3), "negative-exponent");
        Check(Bits(9e2m, 900, 0), "positive-exponent");
        Check(Bits(0.00000m, 0, 5), "zero-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
