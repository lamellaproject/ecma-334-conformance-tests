/*
Rules: E15-8-1-grammar-event-modifier-form-7; E15-8-1-grammar-event-modifier-form-9
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public virtual event Action Signal;
Into: public event Action Signal;
*/
using System;
class Source { public virtual event Action Signal; }
class Derived : Source
{
    public int Adds, Removes;
    public override event Action Signal { add { Adds += 3; } remove { Removes += 5; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived source = new Derived();
        Source receiver = source;
        Action handler = () => { };
        receiver.Signal += handler;
        receiver.Signal -= handler;
        Check(source.Adds == 3, "virtual-add-dispatch");
        Check(source.Removes == 5, "virtual-remove-dispatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
