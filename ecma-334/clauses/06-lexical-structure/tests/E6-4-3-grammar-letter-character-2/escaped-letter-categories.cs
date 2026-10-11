/*
Rules: E6-4-3-grammar-letter-character-2; E6-4-3-identifier-unicode-escapes; E6-4-3-identity-translate-escapes; E6-4-2-escape-identifiers
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int \u03BB = 37;
Into: int \u03BC = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int \u03BB = 37;
        int \u2164 = 41;
        int t\u0061il = 43;
        Check(\U000003BB == 37, "letter-l-category");
        Check(\u2164 == 41, "letter-number-nl-category");
        Check(tail == 43, "letter-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
