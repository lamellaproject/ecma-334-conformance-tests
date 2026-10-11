/*
Rules: E15-6-9-partial-definition-overload-only
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial void Record(int declared);
Into: partial void Record(int other);
*/
using System;
partial class Gauge
{
    int last;
    partial void Record(int declared);
    partial void Record(int used) { last = used; }
    public int Measure() { Record(declared: 73); return last; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().Measure() == 73, "named-argument-binds-to-defining-parameter-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
