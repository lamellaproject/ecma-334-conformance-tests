/*
Rules: E15-8-1-grammar-event-modifier-form-8; E15-8-1-grammar-event-modifier-form-9
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public sealed override event Action Signal
Into: public sealed event Action Signal
*/
using System;
class Source { public virtual event Action Signal; }
class Derived : Source { public int Adds; public sealed override event Action Signal { add { Adds++; } remove { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived source = new Derived();
        ((Source)source).Signal += () => { };
        Check(source.Adds == 1, "sealed-override-add");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
