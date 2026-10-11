/*
Rules: E6-4-5-4-floating-nearest-even; E6-4-5-4-floating-significant-digits
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: float midpoint = 1.000000059604644775390625F;
Into: float midpoint = 1.000000059604644775390626F;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float midpoint = 1.000000059604644775390625F;
        Check(BitConverter.SingleToInt32Bits(midpoint) == 0x3F800000, "even-tie");
        Check(BitConverter.SingleToInt32Bits(1.000000178813934326171875F) == 0x3F800002, "odd-tie");
        Check(BitConverter.SingleToInt32Bits(1.000000059604644775390626F) == 0x3F800001, "last-digit-significant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
