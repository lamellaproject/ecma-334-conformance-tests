/*
Rules: E15-8-5-abstract-event-accessors-virtual
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public abstract event Action Signal;
Into: public event Action Signal;
*/
using System;
abstract class Source { public abstract event Action Signal; }
class Derived : Source { public int Trace; public override event Action Signal { add { Trace += 4; } remove { Trace += 9; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived derived = new Derived();
        Source source = derived;
        Action handler = () => { };
        source.Signal += handler;
        Check(derived.Trace == 4, "abstract-add-override");
        source.Signal -= handler;
        Check(derived.Trace == 13, "abstract-remove-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
