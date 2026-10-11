/*
Rules: E6-4-4-grammar-keyword-18; E6-4-1-grammar-token-4
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: double actual = 12.5D;
Into: bool actual = 12.5D;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double actual = 12.5D;
        Check(BitConverter.DoubleToInt64Bits(actual) == 0x4029000000000000L, "double-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
