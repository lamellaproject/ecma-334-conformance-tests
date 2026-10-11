/*
Rules: E15-2-4-2-default-object-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Gauge : ITag
Into: class Gauge : Other, ITag
*/
using System;
interface ITag { }
class Other
{
    public override bool Equals(object value) { return false; }
    public override int GetHashCode() { return 0; }
}
class Gauge : ITag { public bool Same(object value) { return base.Equals(value); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        Check(gauge.Same(gauge), "interfaces-only-imply-object-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
