/*
Rules: E12-10-2-floating-rounding; E12-10-2-floating-predefined; E12-10-2-floating-iec; E12-10-2-floating-overflow; E12-10-2-floating-underflow-zero; E12-10-2-table-sign-notation
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: F(0x3F800001U) * F(0x3F800001U)
Into: F(0x3F800001U) + F(0x3F800001U)
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static float F(uint bits) { return *(float*)&bits; }
    static double D(ulong bits) { return *(double*)&bits; }
    static bool Bits(float value, uint bits) { return *(uint*)&value == bits; }
    static bool Bits(double value, ulong bits) { return *(ulong*)&value == bits; }
    static void Main()
    {
        // Squaring 1+ulp has an exact low-order term below half an ulp of the product.
        Check(Bits(F(0x3F800001U) * F(0x3F800001U), 0x3F800002U), "single-nearest");
        Check(Bits(D(0x3FF0000000000001UL) * D(0x3FF0000000000001UL), 0x3FF0000000000002UL), "double-nearest");
        Check(Bits(F(0x7F7FFFFFU) * F(0x40000000U), 0x7F800000U), "single-positive-overflow");
        Check(Bits(D(0xFFEFFFFFFFFFFFFFUL) * D(0x4000000000000000UL), 0xFFF0000000000000UL), "double-negative-overflow");
        Check(Bits(F(1U) * F(0x3E800000U), 0U), "single-positive-underflow");
        Check(Bits(F(0x80000001U) * F(0x3E800000U), 0x80000000U), "single-negative-underflow");
        Check(Bits(D(1UL) * D(0x3FD0000000000000UL), 0UL), "double-positive-underflow");
        Check(Bits(D(0x8000000000000001UL) * D(0x3FD0000000000000UL), 0x8000000000000000UL), "double-negative-underflow");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
