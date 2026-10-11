/*
Rules: E6-4-4-grammar-keyword-9; E6-4-1-grammar-token-5
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: char actual = 'Q';
Into: bool actual = 'Q';
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char actual = 'Q';
        Check(actual == 81, "char-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
