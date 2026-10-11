/*
Rules: E15-3-4-virtual-indexer-declarations; E15-3-4-override-inherited-virtual; E15-3-4-polymorphic-dispatch
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override int this[int index]
Into: public new int this[int index]
*/
using System;
class Parent
{
    public int Number;
    public virtual int this[int index] { get { return Number + index; } set { Number = value - index; } }
}
class Child : Parent
{
    public override int this[int index] { get { return Number + 2 * index; } set { Number = value - 2 * index; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent value = new Child();
        value[3] = 367;
        Check(value.Number == 361, "virtual-indexer-setter-dispatch");
        Check(value[5] == 371, "virtual-indexer-getter-dispatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
