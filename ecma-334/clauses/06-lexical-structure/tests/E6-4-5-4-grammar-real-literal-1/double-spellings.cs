/*
Rules: E6-4-5-4-grammar-real-literal-1; E6-4-5-4-grammar-real-literal-2; E6-4-5-4-grammar-real-literal-3; E6-4-5-4-grammar-real-literal-4; E6-4-5-4-grammar-exponent-part-1; E6-4-5-4-grammar-sign-1; E6-4-5-4-grammar-sign-2; E6-4-5-4-unsuffixed-type; E6-4-5-4-grammar-real-type-suffix-3; E6-4-5-4-grammar-real-type-suffix-4; E6-4-5-4-d-type; E6-4-5-1-grammar-literal-3
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: 6_4.1__25
Into: 6_4.1__26
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(double value) { return 1; }
    static int Tag(float value) { return 2; }
    static int Tag(object value) { return 3; }
    static void Main()
    {
        Check(BitConverter.DoubleToInt64Bits(6_4.1__25) == 0x4050080000000000L, "fraction-with-integral-part");
        Check(BitConverter.DoubleToInt64Bits(.375) == 0x3FD8000000000000L, "leading-point");
        Check(7e+2 == 700D, "lower-exponent-plus");
        Check(6.25E-1 == .625d, "upper-exponent-minus");
        Check(63D == 63d, "integer-part-with-suffix");
        Check(7e1__0 == 70000000000D, "exponent-separators");
        Check(Tag(64.125) == 1, "unsuffixed-double");
        Check(Tag(63D) == 1 && Tag(63d) == 1, "d-suffix-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
