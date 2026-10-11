/*
Rules: E23-2-unsafe-event; E23-2-event-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public unsafe event Signal
Into: public event Signal
*/
using System;
delegate void Signal();
class Item
{
    public int Added, Removed;
    public unsafe event Signal Changed
    {
        add { int cell = 7; int* p = &cell; Added = *p; }
        remove { int cell = 9; int* p = &cell; Removed = *p; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        item.Changed += null;
        item.Changed -= null;
        Check(item.Added == 7, "unsafe-event-add-context");
        Check(item.Removed == 9, "unsafe-event-remove-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
