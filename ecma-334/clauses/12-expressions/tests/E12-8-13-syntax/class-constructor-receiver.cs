/*
Rules: E12-8-13-syntax; E12-8-13-class-constructor-type; E12-8-13-class-constructor-reference
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Saved = this;
Into: Saved = null;
*/
using System;
class Vessel<T>
{
    public Vessel<T> Saved;
    public int Tag, Payload;
    static int Kind(Vessel<T> value) { return 1; }
    static int Kind(object value) { return 2; }
    public Vessel(int payload) { Saved = this; Tag = Kind(this); Payload = payload; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var vessel = new Vessel<int>(23);
        Check(object.ReferenceEquals(vessel, vessel.Saved), "constructor-this-is-new-instance");
        Check(vessel.Tag == 1, "constructor-this-has-enclosing-instance-type");
        Check(vessel.Saved != null && vessel.Saved.Payload == 23, "saved-reference-observes-later-construction");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
