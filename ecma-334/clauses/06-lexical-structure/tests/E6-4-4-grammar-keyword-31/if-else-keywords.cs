/*
Rules: E6-4-4-grammar-keyword-31; E6-4-4-grammar-keyword-19
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: else value = 67;
Into: 
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 0;
        if (false) value = 61;
        else value = 67;
        Check(value == 67, "if-else");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
