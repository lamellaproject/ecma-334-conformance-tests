/*
Rules: E6-3-4-grammar-whitespace-3; E6-3-4-grammar-whitespace-1; E6-4-1-whitespace-separator; E6-3-1-separators
Authority: ECMA-334 7th ed 6.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/06-lexical-structure/generators/whitespace-pairs.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        intamount = 19;
        Check(amount == 19, "vertical-tab-then-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
