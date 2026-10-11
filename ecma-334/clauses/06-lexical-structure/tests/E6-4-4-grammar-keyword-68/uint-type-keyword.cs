/*
Rules: E6-4-4-grammar-keyword-68
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: uint actual = 61U;
Into: bool actual = 61U;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        uint actual = 61U;
        Check(actual == 61U, "uint-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
