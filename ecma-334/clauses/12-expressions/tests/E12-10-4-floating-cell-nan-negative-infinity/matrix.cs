/*
Rules: E12-10-4-floating-cell-nan-negative-infinity
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/12-expressions/generators/floating.py
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
    static bool Nan(float value) { return value != value; }
    static bool Nan(double value) { return value != value; }
    static void Main()
    {
        Check(Nan(F(0x7FC00000U) % F(0xFF800000U)), "single-0");
        Check(Nan(D(0x7FF8000000000000UL) % D(0xFFF0000000000000UL)), "double-0");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
