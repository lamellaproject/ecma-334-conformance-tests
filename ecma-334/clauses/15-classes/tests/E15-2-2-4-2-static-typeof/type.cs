/*
Rules: E15-2-2-4-2-static-typeof
Authority: ECMA-334 7th ed 15.2.2.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Type type = typeof(Gauge);
Into: Type type = typeof(object);
*/
using System;
static class Gauge { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type type = typeof(Gauge);
        Check(type != null, "static-typeof-nonnull");
        Check(type != typeof(object), "static-typeof-distinct-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
