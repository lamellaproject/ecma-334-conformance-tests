/*
Rules: E6-4-3-identifier-at-keywords; E6-4-3-grammar-simple-identifier-2; E6-4-3-grammar-escaped-identifier-1
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/06-lexical-structure/generators/identifier-words.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int @string = 61;
        Check(@string == 61, "verbatim-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
