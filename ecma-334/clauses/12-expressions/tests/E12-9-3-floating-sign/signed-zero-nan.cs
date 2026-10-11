/*
Rules: E12-9-3-floating-sign; E12-9-3-floating-predefined; E12-9-3-floating-nan
Authority: ECMA-334 7th ed 12.9.3
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: -F(0x00000000U)
Into: +F(0x00000000U)
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static float F(uint bits) { return *(float*)&bits; }
    static double D(ulong bits) { return *(double*)&bits; }
    static bool Bits(float v, uint b) { return *(uint*)&v == b; }
    static bool Bits(double v, ulong b) { return *(ulong*)&v == b; }
    static bool Nan(float v) { return v != v; }
    static bool Nan(double v) { return v != v; }
    static void Main()
    {
        Check(Bits(-F(0x00000000U), 0x80000000U), "float-positive-zero");
        Check(Bits(-F(0x80000000U), 0x00000000U), "float-negative-zero");
        Check(Bits(-F(0x7F800000U), 0xFF800000U), "float-infinity"); Check(Nan(-F(0x7FC00001U)), "float-nan");
        Check(Bits(-D(0x0000000000000000UL), 0x8000000000000000UL), "double-positive-zero");
        Check(Bits(-D(0x8000000000000000UL), 0x0000000000000000UL), "double-negative-zero");
        Check(Bits(-D(0xFFF0000000000000UL), 0x7FF0000000000000UL), "double-infinity");
        Check(Nan(-D(0x7FF8000000000001UL)), "double-nan");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
