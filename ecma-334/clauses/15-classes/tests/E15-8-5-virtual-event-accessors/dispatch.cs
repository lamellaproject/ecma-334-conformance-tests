/*
Rules: E15-8-5-virtual-event-accessors; E15-8-5-override-event-existing-member; E15-8-5-override-event-modifier; E15-8-5-event-accessor-method-semantics; E15-8-5-event-accessor-method-correspondence
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public virtual event Action Signal
Into: public event Action Signal
*/
using System;
class Source
{
    public int Trace;
    public Action Added, Removed;
    public virtual event Action Signal { add { Trace = Trace * 10 + 2; } remove { Trace = Trace * 10 + 4; } }
}
class Derived : Source
{
    public override event Action Signal
    {
        add { base.Signal += value; Trace = Trace * 10 + 3; Added = value; }
        remove { base.Signal -= value; Trace = Trace * 10 + 5; Removed = value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Derived();
        Action handler = () => { };
        source.Signal += handler;
        Check(source.Trace == 23, "virtual-add-and-base-call");
        Check(source.Added == handler, "add-single-value-parameter");
        source.Signal -= handler;
        Check(source.Trace == 2345, "virtual-remove-and-base-call");
        Check(source.Removed == handler, "remove-single-value-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
