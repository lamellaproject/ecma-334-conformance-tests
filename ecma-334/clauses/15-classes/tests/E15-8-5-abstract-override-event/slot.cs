/*
Rules: E15-8-5-abstract-override-event; E15-8-5-abstract-override-event-accessors
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public abstract override event Action Signal;
Into: public abstract new event Action Signal;
*/
using System;
class Source { public int Trace; public virtual event Action Signal { add { Trace += 10; } remove { Trace += 20; } } }
abstract class Middle : Source { public abstract override event Action Signal; }
class Derived : Middle { public override event Action Signal { add { Trace += 3; } remove { Trace += 7; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Derived();
        Action handler = () => { };
        source.Signal += handler;
        Check(source.Trace == 3, "abstract-override-add-slot");
        source.Signal -= handler;
        Check(source.Trace == 10, "abstract-override-remove-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
