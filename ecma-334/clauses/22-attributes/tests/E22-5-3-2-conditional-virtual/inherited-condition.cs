/*
Rules: E22-5-3-2-conditional-virtual; E22-5-3-2-conditional-override-inherits; E22-5-3-2-conditional-base-calls
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Diagnostics.Conditional("ABSENT")]
Into: [System.Diagnostics.Conditional("PRESENT")]
*/
#define PRESENT
using System;
class Parent
{
    public static int Hits;
    [System.Diagnostics.Conditional("ABSENT")] public virtual void Hit() { Hits += 1; }
}
class Child : Parent
{
    public override void Hit() { Hits += 4; }
    public void ThroughBase() { base.Hit(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child item = new Child();
        item.Hit();
        item.ThroughBase();
        Check(Parent.Hits == 0, "override-and-base-calls-omitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
