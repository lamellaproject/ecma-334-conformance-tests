/*
Rules: E12-10-4-floating-magnitude; E12-10-4-floating-predefined
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: a % b
Into: a / b
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
        float a = 7F, b = 4F; double c = 7D, d = 4D;
        Check(Bits(a % b, 0x40400000U), "single-remainder-three");
        Check(Bits(c % d, 0x4008000000000000UL), "double-remainder-three");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
