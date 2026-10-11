/*
Rules: E15-1-property-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: set { stored = value; }
Into: set { stored = 0; }
*/
using System;
class Meter
{
    int stored;
    public int Reading { get { return stored; } set { stored = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Meter meter = new Meter();
        Check(meter.Reading == 0, "class-property-initial");
        meter.Reading = 23;
        Check(meter.Reading == 23, "class-property-set-get");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
