/*
Rules: E12-9-5-integer-predefined; E12-9-5-bit-complement; E12-9-5-lifted; E12-9-1-form-complement
Authority: ECMA-334 7th ed 12.9.5
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: ~i
Into: i
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int i = 0x12345678; uint u = 0x87654321U; long l = 0x0123456789ABCDEFL; ulong ul = 0xFEDCBA9876543210UL;
        Check(~i == unchecked((int)0xEDCBA987), "int"); Check(~u == 0x789ABCDEU, "uint");
        Check(~l == unchecked((long)0xFEDCBA9876543210UL), "long"); Check(~ul == 0x0123456789ABCDEFUL, "ulong");
        int? value = 2; int? missing = null;
        Check(~value == -3, "lifted-value"); Check(~missing == null, "lifted-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
