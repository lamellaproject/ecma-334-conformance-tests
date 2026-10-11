/*
Rules: E12-10-6-floating-overflow; E12-10-6-floating-predefined; E12-10-6-floating-iec; E12-10-6-floating-equal-values; E12-10-6-table-negated-y
Authority: ECMA-334 7th ed 12.10.6
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: Bits(s - -s, 0x7F800000U)
Into: Bits(s + -s, 0x7F800000U)
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
        float s = float.MaxValue, z = 0F, n = -3F; double d = double.MaxValue, dz = 0D, dn = -3D;
        Check(Bits(s - -s, 0x7F800000U), "single-positive-overflow");
        Check(Bits(-s - s, 0xFF800000U), "single-negative-overflow");
        Check(Bits(d - -d, 0x7FF0000000000000UL), "double-positive-overflow");
        Check(Bits(-d - d, 0xFFF0000000000000UL), "double-negative-overflow");
        Check(Bits(-s - -s, 0U), "single-equal-negative-values");
        Check(Bits(-d - -d, 0UL), "double-equal-negative-values");
        Check(Bits(z - n, 0x40400000U), "single-negated-negative-y");
        Check(Bits(dz - dn, 0x4008000000000000UL), "double-negated-negative-y");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
