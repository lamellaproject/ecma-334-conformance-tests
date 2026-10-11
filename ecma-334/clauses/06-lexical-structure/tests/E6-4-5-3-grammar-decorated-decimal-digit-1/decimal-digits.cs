/*
Rules: E6-4-5-3-grammar-decorated-decimal-digit-1; E6-4-5-3-grammar-decimal-digit-1; E6-4-5-3-grammar-decimal-integer-literal-1; E6-4-5-3-decimal-value; E6-4-5-1-grammar-literal-2; E6-4-5-1-literal-value; E6-3-1-fragment-component; E6-3-1-fragment-order
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: 9__876_543_210UL
Into: 9__876_543_211UL
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ulong allDigits = 9__876_543_210UL;
        Check(allDigits == 9876543210UL, "all-decimal-digits");
        Check(0073 == 73, "leading-zero-decimal");
        Check(5____7 == 57, "multiple-separators");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
