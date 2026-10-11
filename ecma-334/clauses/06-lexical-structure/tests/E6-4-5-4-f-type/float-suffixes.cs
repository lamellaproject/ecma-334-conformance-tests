/*
Rules: E6-4-5-4-f-type; E6-4-5-4-grammar-real-type-suffix-1; E6-4-5-4-grammar-real-type-suffix-2
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Tag(23F)
Into: Tag(23D)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(float value) { return 1; }
    static int Tag(double value) { return 2; }
    static void Main()
    {
        Check(Tag(23F) == 1, "upper-f-type");
        Check(Tag(.875f) == 1, "lower-f-type");
        Check(BitConverter.SingleToInt32Bits(.875f) == 0x3F600000, "float-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
