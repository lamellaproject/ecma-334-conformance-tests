/*
Rules: E15-1-inheritance
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Gauge : Meter
Into: class Gauge : object
*/
using System;
class Meter
{
    public int Scale = 3;
    public virtual int Read() { return 11; }
}
class Gauge : Meter
{
    public override int Read() { return Scale + 17; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        Meter meter = gauge;
        Check(gauge.Scale == 3, "class-inheritance-extends");
        Check(meter.Read() == 20, "class-inheritance-specializes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
