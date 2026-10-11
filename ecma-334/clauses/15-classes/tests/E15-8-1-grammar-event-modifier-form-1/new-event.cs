/*
Rules: E15-8-1-grammar-event-modifier-form-1
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new event Action Signal;
Into: public static event Action Signal;
*/
using System;
class Source { public event Action Signal; public void Notify() { Signal(); } }
class Derived : Source { public new event Action Signal; public void NotifyNew() { Signal(); } }
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived source = new Derived();
        ((Source)source).Signal += () => trace += 4;
        source.Signal += () => trace += 7;
        source.Notify();
        Check(trace == 4, "base-event");
        source.NotifyNew();
        Check(trace == 11, "new-event");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
