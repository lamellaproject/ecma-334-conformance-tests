/*
Rules: E15-8-1-event-accessibility; E15-8-1-grammar-event-modifier-form-4
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal event Action Signal;
Into: private event Action Signal;
*/
using System;
class Source { internal event Action Signal; public void Notify() { Signal(); } }
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        source.Signal += () => calls++;
        source.Notify();
        Check(calls == 1, "internal-event-in-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
