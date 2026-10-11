/*
Rules: E6-4-5-3-grammar-decorated-hex-digit-1; E6-4-5-3-grammar-hex-digit-1; E6-4-5-3-grammar-hex-digit-2; E6-4-5-3-grammar-hex-digit-3; E6-4-5-3-grammar-hexadecimal-integer-literal-1; E6-4-5-3-hexadecimal-value
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: 0X__FEDC__BA98_7654_3210UL
Into: 0X__FEDC__BA98_7654_3211UL
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(0X__FEDC__BA98_7654_3210UL == 18364758544493064720UL, "uppercase-all-digits");
        Check(0xabcdef == 11259375, "lowercase-letters");
        Check(0x0 == 0, "zero-digit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
