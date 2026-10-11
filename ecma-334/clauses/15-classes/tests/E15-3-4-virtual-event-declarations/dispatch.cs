/*
Rules: E15-3-4-virtual-event-declarations; E15-3-4-override-inherited-virtual; E15-3-4-polymorphic-dispatch
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override event Notice Signal
Into: public new event Notice Signal
*/
using System;
delegate void Notice();
class Parent
{
    public int Adds, Removes;
    public virtual event Notice Signal { add { Adds++; } remove { Removes++; } }
}
class Child : Parent
{
    public override event Notice Signal { add { Adds += 2; } remove { Removes += 2; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Notify() { }
    static void Main()
    {
        Parent value = new Child();
        value.Signal += Notify;
        value.Signal -= Notify;
        Check(value.Adds == 2, "virtual-event-add-accessor-dispatch");
        Check(value.Removes == 2, "virtual-event-remove-accessor-dispatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
