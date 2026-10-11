/*
Rules: E12-10-3-floating-rounding; E12-10-3-floating-predefined; E12-10-3-floating-iec
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Bits(one / three, 0x3EAAAAABU)
Into: Bits(one * three, 0x3EAAAAABU)
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Bits(float value, uint bits) { return *(uint*)&value == bits; }
    static bool Bits(double value, ulong bits) { return *(ulong*)&value == bits; }
    static void Main()
    {
        float one = 1F, three = 3F; double dOne = 1D, dThree = 3D;
        Check(Bits(one / three, 0x3EAAAAABU), "single-nearest-third");
        Check(Bits(-one / three, 0xBEAAAAABU), "single-negative-third");
        Check(Bits(dOne / dThree, 0x3FD5555555555555UL), "double-nearest-third");
        Check(Bits(-dOne / dThree, 0xBFD5555555555555UL), "double-negative-third");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
