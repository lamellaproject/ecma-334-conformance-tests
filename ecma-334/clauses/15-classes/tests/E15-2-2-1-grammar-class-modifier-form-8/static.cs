/*
Rules: E15-2-2-1-grammar-class-modifier-form-8; E15-2-2-4-1-static-designation
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static class Gauge
Into: static struct Gauge
*/
using System;
static class Gauge { public static int Read() { return 103; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.Read() == 103, "static-class-modifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
