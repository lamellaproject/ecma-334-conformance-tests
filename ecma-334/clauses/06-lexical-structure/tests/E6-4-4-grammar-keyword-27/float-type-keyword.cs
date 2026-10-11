/*
Rules: E6-4-4-grammar-keyword-27
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: float actual = 12.5F;
Into: bool actual = 12.5F;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float actual = 12.5F;
        Check(BitConverter.SingleToInt32Bits(actual) == 0x41480000, "float-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
