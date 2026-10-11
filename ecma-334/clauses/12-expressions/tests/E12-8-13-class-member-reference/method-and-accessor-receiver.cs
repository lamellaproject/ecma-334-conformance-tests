/*
Rules: E12-8-13-class-member-reference; E12-8-13-class-member-type
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return this;
Into: return new Vessel<T>();
*/
using System;
class Vessel<T>
{
    public int Tag;
    static int Kind(Vessel<T> value) { return 1; }
    static int Kind(object value) { return 2; }
    public Vessel<T> Self() { Tag = Kind(this); return this; }
    public Vessel<T> Receiver { get { Tag = Kind(this); Vessel<T> receiver = this; return receiver; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var vessel = new Vessel<string>();
        Check(object.ReferenceEquals(vessel, vessel.Self()), "method-this-is-invoked-instance");
        Check(vessel.Tag == 1, "method-this-has-enclosing-instance-type");
        vessel.Tag = 0;
        Check(object.ReferenceEquals(vessel, vessel.Receiver), "accessor-this-is-invoked-instance");
        Check(vessel.Tag == 1, "accessor-this-has-enclosing-instance-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
