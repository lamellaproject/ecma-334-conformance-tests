/*
Rules: E15-1-nested-types
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Gauge
Into: public interface Gauge
*/
using System;
class Meter
{
    public class Gauge { public int Read() { return 43; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter.Gauge().Read() == 43, "class-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
