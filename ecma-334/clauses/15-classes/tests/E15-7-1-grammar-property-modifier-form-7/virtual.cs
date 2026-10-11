/*
Rules: E15-7-1-grammar-property-modifier-form-7
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public virtual int Token
Into: public int Token
*/
using System;
class Base { public virtual int Token => 10; }
class Derived : Base { public override int Token => 25; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); Check(box.Token == 25, "virtual-property"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
