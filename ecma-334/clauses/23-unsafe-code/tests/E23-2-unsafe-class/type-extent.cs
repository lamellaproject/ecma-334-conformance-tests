/*
Rules: E23-2-unsafe-class; E23-2-class-context; E23-2-form-modifier; E23-2-modifier-effect-type
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: unsafe class Item
Into: class Item
*/
using System;
interface Contract { int Read(); }
class Parent { public virtual int Read() { return 3; } }
unsafe class Item : Parent, Contract
{
    public override int Read() { int value = 7; int* p = &value; *p += 2; return Nested.Add(p); }
    class Nested { public static int Add(int* p) { return *p + 1; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        Check(item.Read() == 10, "class-body-and-nested-type");
        Check(((Contract)item).Read() == 10, "ordinary-interface-use");
        Check(((Parent)item).Read() == 10, "ordinary-virtual-dispatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
