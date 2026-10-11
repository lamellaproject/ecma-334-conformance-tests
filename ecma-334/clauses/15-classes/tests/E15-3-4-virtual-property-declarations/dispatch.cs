/*
Rules: E15-3-4-virtual-property-declarations; E15-3-4-override-inherited-virtual; E15-3-4-polymorphic-dispatch
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public override int Level
Into: public new int Level
*/
using System;
class Parent
{
    public int Number;
    public virtual int Level { get { return Number + 1; } set { Number = value + 1; } }
}
class Child : Parent
{
    public override int Level { get { return Number + 2; } set { Number = value + 2; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent derived = new Child();
        derived.Level = 353;
        Check(derived.Number == 355, "virtual-property-setter-dispatch");
        Check(derived.Level == 357, "virtual-property-getter-dispatch");
        Parent plain = new Parent();
        plain.Level = 359;
        Check(plain.Number == 360 && plain.Level == 361, "base-property-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
