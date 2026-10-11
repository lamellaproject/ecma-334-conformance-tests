/*
Rules: E15-6-9-partial-cross-part-implementation; E15-6-9-partial-implementing-body
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial void Record(int amount) { value = amount * 3; }
Into: partial void Record(int amount) { }
*/
using System;
partial class Gauge
{
    int value;
    partial void Record(int declared);
    public int Measure(int input) { Record(input); return value; }
}
partial class Gauge { partial void Record(int amount) { value = amount * 3; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        Check(gauge.Measure(17) == 51, "definition-in-first-part-executes-body-from-second-part");
        Check(gauge.Measure(23) == 69, "cross-part-implementation-receives-each-invocation-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
