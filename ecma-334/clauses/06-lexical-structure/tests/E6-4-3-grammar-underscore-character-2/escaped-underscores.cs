/*
Rules: E6-4-3-grammar-underscore-character-2; E6-4-3-identifier-unicode-escapes; E6-4-3-identity-translate-escapes; E6-4-3-identifier-equivalence
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int \u005Fhigh = 37;
Into: int \u0031high = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int \u005Fhigh = 37;
        int \u005flower = 41;
        Check(_high == 37, "uppercase-hex-underscore");
        Check(_lower == 41, "lowercase-hex-underscore");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
