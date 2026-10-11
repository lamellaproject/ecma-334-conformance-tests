/*
Rules: E15-1-event-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public event Signal Pulse;
Into: public event int Pulse;
*/
using System;
delegate void Signal();
class Meter
{
    public event Signal Pulse;
    public void Fire() { if (Pulse != null) Pulse(); }
}
class Program
{
    static int hits;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Receive() { hits++; }
    static void Main()
    {
        Meter meter = new Meter();
        meter.Pulse += Receive;
        meter.Fire();
        Check(hits == 1, "class-event");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
