/*
Rules: E15-7-6-abstract-override-property; E15-7-6-abstract-override-accessors
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: abstract override int Item
Into: abstract new int Item
*/
using System;
class Base { int slot; public virtual int Item { get { return slot; } set { slot = value; } } }
abstract class Middle : Base { public abstract override int Item { get; set; } }
class Derived : Middle { int slot; public override int Item { get { return slot + 4; } set { slot = value + 3; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); box.Item = 17; Check(box.Item == 24, "reabstracted-virtual-accessors"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
