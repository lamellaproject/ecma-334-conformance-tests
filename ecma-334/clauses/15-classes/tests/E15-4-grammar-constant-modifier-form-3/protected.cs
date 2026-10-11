/*
Rules: E15-4-grammar-constant-modifier-form-3; E15-4-constant-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected const int Code = 503;
Into: private const int Code = 503;
*/
using System;
class Basis { protected const int Code = 503; }
class Leaf : Basis { public static int Read() { return Code; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Leaf.Read() == 503, "protected-constant-in-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
