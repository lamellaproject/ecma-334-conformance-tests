/*
Rules: E15-8-5-override-event-sealed; E15-8-5-sealed-event-accessors
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public sealed override event Action Signal
Into: public sealed event Action Signal
*/
using System;
class Source { public int Trace; public virtual event Action Signal { add { Trace++; } remove { Trace += 2; } } }
class Derived : Source { public sealed override event Action Signal { add { Trace += 4; } remove { Trace += 8; } } }
class Leaf : Derived { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Leaf();
        Action handler = () => { };
        source.Signal += handler;
        Check(source.Trace == 4, "sealed-add-inherited");
        source.Signal -= handler;
        Check(source.Trace == 12, "sealed-remove-inherited");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
