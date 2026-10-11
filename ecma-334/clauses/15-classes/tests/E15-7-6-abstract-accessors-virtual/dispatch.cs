/*
Rules: E15-7-6-abstract-accessors-virtual; E15-7-6-abstract-accessors-no-implementation
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public abstract int Item
Into: public int Item
*/
using System;
abstract class Base { public abstract int Item { get; set; } }
class Derived : Base { int slot; public override int Item { get { return slot + 2; } set { slot = value + 3; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); box.Item = 23; Check(box.Item == 28, "abstract-accessor-dispatch"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
