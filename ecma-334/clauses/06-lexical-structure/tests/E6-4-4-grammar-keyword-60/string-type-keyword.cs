/*
Rules: E6-4-4-grammar-keyword-60; E6-4-1-grammar-token-6
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string actual = "bay";
Into: object actual = "bay";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string actual = "bay";
        Check(actual.Length == 3 && actual[1] == 97, "string-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
