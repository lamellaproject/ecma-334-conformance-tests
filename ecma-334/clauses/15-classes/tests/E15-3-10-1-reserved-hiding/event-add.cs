/*
Rules: E15-3-10-1-reserved-hiding
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public new void add_Changed(Signal handler)
Into: public new void Subscribe(Signal handler)
*/
using System;
class Root
{
    public delegate void Signal();
    public event Signal Changed { add { } remove { } }
}
class Leaf : Root
{
    public int Adds;
    public new void add_Changed(Signal handler) { Adds++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void OnSignal() { }
    static void Main()
    {
        Leaf leaf = new Leaf();
        leaf.add_Changed(OnSignal);
        Check(leaf.Adds == 1, "new-method-hides-inherited-event-add-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
