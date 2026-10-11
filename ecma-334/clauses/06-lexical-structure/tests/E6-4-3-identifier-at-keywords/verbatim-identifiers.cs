/*
Rules: E6-4-3-identifier-at-keywords; E6-4-3-grammar-simple-identifier-2; E6-4-3-grammar-escaped-identifier-1; E6-4-3-identity-remove-at; E6-4-3-identifier-equivalence
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int @class = 37;
Into: int class = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int @class = 37;
        int @node = 41;
        Check(@class == 37, "verbatim-keyword-name");
        Check(node == 41, "at-prefix-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
