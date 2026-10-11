/*
Rules: E15-7-6-override-property-sealed
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: sealed override int Item
Into: sealed int Item
*/
using System;
class Base { public virtual int Item { get { return 11; } } }
class Derived : Base { public sealed override int Item { get { return 43; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); Check(box.Item == 43, "sealed-override-dispatch"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
