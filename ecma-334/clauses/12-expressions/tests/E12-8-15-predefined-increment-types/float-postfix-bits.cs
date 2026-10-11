/*
Rules: E12-8-15-predefined-increment-types; E12-8-15-predefined-decrement-types; E12-8-15-increment-value; E12-8-15-decrement-value; E12-8-15-result-type
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: float before = value++;
Into: float before = value--;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static uint Bits(float value) { return *(uint*)&value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float value = 4.0F; float before = value++;
        Check(Bits(before) == 0x40800000U, "float-increment-old-bits");
        Check(Bits(value) == 0x40a00000U, "float-increment-new-bits");
        before = value--;
        Check(Bits(before) == 0x40a00000U, "float-decrement-old-bits");
        Check(Bits(value) == 0x40800000U, "float-decrement-new-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
