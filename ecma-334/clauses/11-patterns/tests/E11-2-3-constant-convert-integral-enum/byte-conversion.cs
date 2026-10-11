/*
Rules: E11-2-3-constant-convert-integral-enum; E11-2-3-grammar-constant-pattern-1; E11-2-3-constant-applicability; E11-2-3-constant-numeric-match
Authority: ECMA-334 7th ed 11.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is 29
Into: source is 30
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Matches(byte source) { return source is 29; }
    static void Main()
    {
        Check(Matches(29), "converted-integral-equal");
        Check(!Matches(30), "converted-integral-different");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
