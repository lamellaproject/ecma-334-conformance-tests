/*
Rules: E15-2-4-1-grammar-class-base-form-2
Authority: ECMA-334 7th ed 15.2.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Gauge : IReading
Into: class Gauge
*/
using System;
interface IReading { int Read(); }
class Gauge : IReading { public int Read() { return 197; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IReading gauge = new Gauge();
        Check(gauge.Read() == 197, "interface-only-base-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
