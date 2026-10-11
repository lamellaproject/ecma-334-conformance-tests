/*
Rules: E6-4-5-4-floating-nearest-even; E6-4-5-4-floating-significant-digits
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: double midpoint = 1.00000000000000011102230246251565404236316680908203125D;
Into: double midpoint = 1.00000000000000011102230246251565404236316680908203126D;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double midpoint = 1.00000000000000011102230246251565404236316680908203125D;
        Check(BitConverter.DoubleToInt64Bits(midpoint) == 0x3FF0000000000000L, "even-tie");
        double odd = 1.00000000000000033306690738754696212708950042724609375D;
        Check(BitConverter.DoubleToInt64Bits(odd) == 0x3FF0000000000002L, "odd-tie");
        double above = 1.00000000000000011102230246251565404236316680908203126D;
        Check(BitConverter.DoubleToInt64Bits(above) == 0x3FF0000000000001L, "last-digit-significant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
