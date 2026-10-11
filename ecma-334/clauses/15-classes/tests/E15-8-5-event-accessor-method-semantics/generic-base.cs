/*
Rules: E15-8-5-event-accessor-method-semantics; E15-8-5-override-event-type-identity
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public virtual event Action<T> Signal
Into: public event Action<T> Signal
*/
using System;
class Source<T> { public virtual event Action<T> Signal { add { } remove { } } }
class Derived : Source<int>
{
    public Action<int> Added, Removed;
    public override event Action<int> Signal { add { Added = value; } remove { Removed = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived derived = new Derived();
        Source<int> source = derived;
        Action<int> handler = value => { };
        source.Signal += handler;
        source.Signal -= handler;
        Check(derived.Added == handler, "substituted-add-parameter");
        Check(derived.Removed == handler, "substituted-remove-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
