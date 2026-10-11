/*
Rules: E15-8-4-static-event-classification; E15-8-4-static-event-no-instance
Authority: ECMA-334 7th ed 15.8.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static event Action Signal;
Into: public event Action Signal;
*/
using System;
class Source { public static event Action Signal; public void Notify() { Signal(); } }
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source.Signal += () => calls++;
        new Source().Notify();
        Check(calls == 1, "static-handler-first-instance");
        new Source().Notify();
        Check(calls == 2, "static-handler-second-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
