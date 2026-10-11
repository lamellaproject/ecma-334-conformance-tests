/*
Rules: E15-3-10-3-reserve-event-add; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public void add_Changed(int unused)
Into: public void add_Changed(Signal unused)
*/
using System;
class Gauge
{
    public delegate void Signal();
    public event Signal Changed { add { } remove { } }
    public void add_Changed(int unused) { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
