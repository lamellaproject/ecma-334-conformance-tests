/*
Rules: E15-3-4-virtual-method-declarations; E15-3-4-override-inherited-virtual; E15-3-4-polymorphic-dispatch
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override int Read() { return 349; }
Into: public new int Read() { return 349; }
*/
using System;
class Parent { public virtual int Read() { return 347; } }
class Child : Parent { public override int Read() { return 349; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent derived = new Child();
        Parent plain = new Parent();
        Check(derived.Read() == 349, "base-reference-dispatches-to-runtime-child-method");
        Check(plain.Read() == 347, "base-instance-dispatches-to-base-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
