/*
Rules: E15-1-field-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Slot = 17;
Into: public const int Slot = 17;
*/
using System;
class Meter
{
    public int Slot = 17;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Meter meter = new Meter();
        Check(meter.Slot == 17, "class-field-initial");
        meter.Slot = 31;
        Check(meter.Slot == 31, "class-field-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
