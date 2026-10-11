/*
Rules: E6-2-5-is-expression-fallback
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Limit = 29
Into: Limit = 30
*/
using System;
class Constants { public const int Limit = 29; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object matching = 29, different = 30;
        Check(matching is Constants.Limit, "qualified-constant-match");
        Check(!(different is Constants.Limit), "qualified-constant-mismatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
