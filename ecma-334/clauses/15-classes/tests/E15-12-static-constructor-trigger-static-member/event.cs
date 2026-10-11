/*
Rules: E15-12-static-constructor-trigger-static-member
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Gauge()
Into: private Gauge()
*/
using System;
class Gauge { public static event Action Signal; static Gauge() { Program.Calls++; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void OnSignal() { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Calls == 0, "event-trigger-not-earlier");
        Gauge.Signal += OnSignal;
        Check(Calls == 1, "first-event-reference-trigger");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
