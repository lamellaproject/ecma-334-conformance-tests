/*
Rules: E6-4-4-grammar-keyword-4; E6-4-4-grammar-keyword-24; E6-4-4-grammar-keyword-65; E6-4-1-grammar-token-2
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: bool actual = true;
Into: int actual = true;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool actual = true;
        Check(actual && !false, "bool-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
