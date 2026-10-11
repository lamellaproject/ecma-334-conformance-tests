/*
Rules: E15-5-1-grammar-field-modifier-form-3; E15-5-1-field-accessibility
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int Code = 509;
Into: private int Code = 509;
*/
using System;
class Basis { protected int Code = 509; }
class Leaf : Basis { public int Read() { return Code; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Leaf().Read() == 509, "protected-field-in-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
