/*
Rules: E15-8-1-event-accessibility; E15-8-1-grammar-event-modifier-form-3
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected event Action Signal;
Into: private event Action Signal;
*/
using System;
class Source { protected event Action Signal; public void Notify() { Signal(); } }
class Derived : Source { public void Attach(Action handler) { Signal += handler; } }
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived source = new Derived();
        source.Attach(() => calls++);
        source.Notify();
        Check(calls == 1, "protected-event-in-derived");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
