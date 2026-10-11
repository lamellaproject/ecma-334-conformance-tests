/*
Rules: E15-4-grammar-constant-modifier-form-4; E15-4-constant-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal const int Code = 607;
Into: private const int Code = 607;
*/
using System;
class Limits { internal const int Code = 607; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Code == 607, "internal-constant-in-same-program");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
