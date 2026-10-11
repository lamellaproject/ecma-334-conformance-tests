/*
Rules: E6-4-4-grammar-keyword-34; E6-4-1-grammar-token-3
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int actual = 61;
Into: bool actual = 61;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int actual = 61;
        Check(actual == 61, "int-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
