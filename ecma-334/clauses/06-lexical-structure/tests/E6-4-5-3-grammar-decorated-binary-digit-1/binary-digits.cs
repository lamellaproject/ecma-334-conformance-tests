/*
Rules: E6-4-5-3-grammar-decorated-binary-digit-1; E6-4-5-3-grammar-binary-digit-1; E6-4-5-3-grammar-binary-digit-2; E6-4-5-3-grammar-binary-integer-literal-1; E6-4-5-3-binary-value
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: 0B__110__01
Into: 0B__110__00
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(0B__110__01 == 25, "uppercase-and-separators");
        Check(0b100100 == 36, "lowercase-prefix");
        Check(0b0 == 0, "zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
