/*
Rules: E12-10-4-floating-cell-negative-zero-negative-finite
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
        Check(Bits(F(0x80000000U) % F(0xC0000000U), 0x80000000U), "single-0");
        Check(Bits(D(0x8000000000000000UL) % D(0xC000000000000000UL), 0x8000000000000000UL), "double-0");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
