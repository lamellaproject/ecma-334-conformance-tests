/*
Rules: E12-8-11-3-initial-candidates; E12-8-11-3-exclude-overrides; E12-8-11-3-remove-base-indexers
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver[5]
Into: ((Base)receiver)[5]
*/
using System;
class Base { public virtual int this[int index] { get { return 1; } } }
class Derived : Base
{
    public override int this[int index] { get { return 2; } }
    public int this[object index] { get { return 3; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        Check(receiver[5] == 3, "override-is-not-derived-candidate-and-applicable-derived-object-removes-base-int");
        Base baseView = receiver;
        Check(baseView[5] == 2, "inherited-base-candidate-still-dispatches-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
