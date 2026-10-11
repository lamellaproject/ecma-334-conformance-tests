/*
Rules: E15-2-4-2-default-object-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Gauge { public bool Same(object value)
Into: class Gauge : Other { public bool Same(object value)
*/
using System;
class Other
{
    public override bool Equals(object value) { return false; }
    public override int GetHashCode() { return 0; }
}
class Gauge { public bool Same(object value) { return base.Equals(value); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        Check(gauge.Same(gauge), "implicit-object-base-equals-self");
        Check(!gauge.Same(new object()), "implicit-object-base-equals-other");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
