/*
Rules: E15-3-2-nongeneric-instance-type
Authority: ECMA-334 7th ed 15.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Gauge Self() { return this; }
Into: public Gauge Self() { return new Gauge(); }
*/
using System;
class Gauge { public Gauge Self() { return this; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge value = new Gauge();
        Gauge same = value.Self();
        Check((object)same == (object)value, "nongeneric-this-has-declared-class-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
