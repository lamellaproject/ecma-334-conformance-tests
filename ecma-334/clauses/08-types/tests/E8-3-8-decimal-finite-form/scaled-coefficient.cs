/*
Rules: E8-3-8-decimal-finite-form; E8-3-8-decimal-sign; E8-3-8-decimal-scale; E8-3-8-decimal-scaled-integer; E8-3-8-decimal-coefficient
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new decimal(12345, 0, 0, true, 4)
Into: new decimal(12346, 0, 0, true, 4)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal value = new decimal(12345, 0, 0, true, 4); int[] bits = decimal.GetBits(value);
        Check(value == -1.2345m && bits[0] == 12345 && bits[1] == 0 && bits[2] == 0 && bits[3] == unchecked((int)0x80040000), "signed-coefficient-times-power-of-ten");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
