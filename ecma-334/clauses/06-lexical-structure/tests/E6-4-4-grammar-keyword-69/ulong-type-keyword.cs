/*
Rules: E6-4-4-grammar-keyword-69
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ulong actual = 61UL;
Into: bool actual = 61UL;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ulong actual = 61UL;
        Check(actual == 61UL, "ulong-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
