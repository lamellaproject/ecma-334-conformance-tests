/*
Rules: E6-4-4-grammar-keyword-14
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal actual = 12.5M;
Into: bool actual = 12.5M;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal actual = 12.5M;
        Check(actual == 25M / 2M, "decimal-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
