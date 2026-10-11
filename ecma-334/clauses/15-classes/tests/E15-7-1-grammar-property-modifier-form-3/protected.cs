/*
Rules: E15-7-1-grammar-property-modifier-form-3; E15-7-1-property-accessibility
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int Token
Into: private int Token
*/
using System;
class Base { protected int Token => 17; }
class Derived : Base { public int Read() { return Token; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Derived().Read() == 17, "protected-property"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
