/*
Rules: E15-7-1-grammar-property-modifier-form-9
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: override int Token
Into: new int Token
*/
using System;
class Base { public virtual int Token => 2; }
class Derived : Base { public override int Token => 35; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); Check(box.Token == 35, "override-property"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
