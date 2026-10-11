/*
Rules: E15-6-9-partial-same-part; E15-6-9-partial-implemented-retains-invocations; E15-6-9-partial-result-implementation
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial void Add(int amount) { total += amount; }
Into: // implementation removed
*/
using System;
partial class Gauge
{
    int total;
    partial void Add(int declared);
    partial void Add(int amount) { total += amount; }
    public int Measure() { Add(11); Add(31); return total; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        Check(gauge.Measure() == 42, "same-part-implementation-retains-both-invocations");
        Check(gauge.Measure() == 84, "resulting-method-retains-implementation-state-effects");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
