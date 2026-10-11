/*
Rules: E6-4-4-grammar-contextual-keyword-28; E6-4-4-contextual-identifier; E6-4-4-contextual-verbatim-identifier; E6-4-3-grammar-identifier-2; E6-4-3-identity-remove-at
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
            int where = 61;
            Check(@where == 61, "ordinary-declaration-verbatim-reference");
        }
        {
            int @where = 67;
            Check(where == 67, "verbatim-declaration-ordinary-reference");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
