/*
Rules: E6-4-4-grammar-keyword-39
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long actual = 61L;
Into: bool actual = 61L;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long actual = 61L;
        Check(actual == 61L, "long-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
