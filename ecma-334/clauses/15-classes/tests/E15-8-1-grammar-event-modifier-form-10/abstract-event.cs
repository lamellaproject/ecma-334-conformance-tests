/*
Rules: E15-8-1-grammar-event-modifier-form-10
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public abstract event Action Signal;
Into: public event Action Signal;
*/
using System;
abstract class Source { public abstract event Action Signal; }
class Derived : Source { public int Adds; public override event Action Signal { add { Adds++; } remove { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived source = new Derived();
        ((Source)source).Signal += () => { };
        Check(source.Adds == 1, "abstract-event-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
