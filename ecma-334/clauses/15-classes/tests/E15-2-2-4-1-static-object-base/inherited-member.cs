/*
Rules: E15-2-2-4-1-static-object-base
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Gauge.ReferenceEquals(first, second)
Into: Gauge.MissingReferenceEquals(first, second)
*/
using System;
static class Gauge { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // Inherited Object members expose the implicit base without reflection.
        object first = new object();
        object second = first;
        Check(Gauge.ReferenceEquals(first, second), "static-inherited-object-member");
        Check(!Gauge.ReferenceEquals(first, new object()), "static-inherited-object-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
