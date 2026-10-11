/*
Rules: E6-4-3-identity-remove-format; E6-4-3-grammar-formatting-character-2; E6-4-3-grammar-identifier-part-character-5; E6-4-3-identifier-equivalence
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int link\u200Dage = 37;
Into: int link\u0062age = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int link\u200Dage = 37;
        Check(linkage == 37, "cf-removed-after-escape-translation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
