/*
Rules: E6-4-4-grammar-contextual-keyword-22; E6-4-4-contextual-identifier; E6-4-4-contextual-verbatim-identifier; E6-4-3-grammar-identifier-2; E6-4-3-identity-remove-at
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/06-lexical-structure/generators/identifier-words.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            int select = 61;
            Check(@select == 61, "ordinary-declaration-verbatim-reference");
        }
        {
            int @select = 67;
            Check(select == 67, "verbatim-declaration-ordinary-reference");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
