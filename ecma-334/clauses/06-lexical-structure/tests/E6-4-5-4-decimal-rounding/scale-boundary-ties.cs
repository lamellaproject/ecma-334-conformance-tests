/*
Rules: E6-4-5-4-decimal-rounding
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: 0.00000000000000000000000000025m
Into: 0.00000000000000000000000000026m
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Bits(decimal value, int coefficient)
    {
        int[] bits = decimal.GetBits(value);
        return bits[0] == coefficient && bits[1] == 0 && bits[2] == 0 && bits[3] == 1835008;
    }
    static void Main()
    {
        Check(Bits(0.00000000000000000000000000025m, 2), "even-tie-down");
        Check(Bits(0.00000000000000000000000000035m, 4), "odd-tie-up");
        Check(Bits(0.00000000000000000000000000026m, 3), "above-tie");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
