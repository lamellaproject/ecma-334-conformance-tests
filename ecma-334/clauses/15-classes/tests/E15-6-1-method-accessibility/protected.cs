/*
Rules: E15-6-1-method-accessibility; E15-6-1-grammar-ref-method-modifier-form-3
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int Read() { return 29; }
Into: private int Read() { return 29; }
*/
using System;
class Parent { protected int Read() { return 29; } }
class Holder : Parent { public int Touch() { return Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Touch() == 29, "protected-method-access-in-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
