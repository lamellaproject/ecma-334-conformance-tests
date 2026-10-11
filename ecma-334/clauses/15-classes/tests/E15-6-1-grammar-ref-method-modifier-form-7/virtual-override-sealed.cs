/*
Rules: E15-6-1-grammar-ref-method-modifier-form-7; E15-6-1-grammar-ref-method-modifier-form-8; E15-6-1-grammar-ref-method-modifier-form-9
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public sealed override int Read() { return 47; }
Into: public new int Read() { return 47; }
*/
using System;
class Parent { public virtual int Read() { return 7; } }
class Holder : Parent { public sealed override int Read() { return 47; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Parent parent = value;
        Check(value.Read() == 47, "sealed-override-direct-call");
        Check(parent.Read() == 47, "virtual-call-dispatches-sealed-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
