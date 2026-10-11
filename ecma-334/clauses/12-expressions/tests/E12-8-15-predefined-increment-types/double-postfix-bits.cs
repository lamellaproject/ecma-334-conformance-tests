/*
Rules: E12-8-15-predefined-increment-types; E12-8-15-predefined-decrement-types; E12-8-15-increment-value; E12-8-15-decrement-value; E12-8-15-result-type
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: double before = value++;
Into: double before = value--;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static ulong Bits(double value) { return *(ulong*)&value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double value = 4.0; double before = value++;
        Check(Bits(before) == 0x4010000000000000UL, "double-increment-old-bits");
        Check(Bits(value) == 0x4014000000000000UL, "double-increment-new-bits");
        before = value--;
        Check(Bits(before) == 0x4014000000000000UL, "double-decrement-old-bits");
        Check(Bits(value) == 0x4010000000000000UL, "double-decrement-new-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
