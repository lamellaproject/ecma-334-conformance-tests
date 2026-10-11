/*
Rules: E15-7-6-override-read-write-single-or-both
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: override int Item
Into: new int Item
*/
using System;
class Base { int slot; public virtual int Item { get { return slot; } set { slot = value; } } }
class Derived : Base { public override int Item { get { return base.Item + 2; } set { base.Item = value + 4; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); box.Item = 27; Check(box.Item == 33, "both-accessors-overridden"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
