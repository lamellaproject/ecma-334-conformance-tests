/*
Rules: E15-3-10-1-reserved-not-lookup
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int add_Changed = 467;
Into: public int Other = 467;
*/
using System;
class Root { public int add_Changed = 467; public int remove_Changed = 479; }
class Leaf : Root
{
    public delegate void Signal();
    public event Signal Changed { add { } remove { } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.add_Changed == 467, "reserved-event-add-name-does-not-hide-field-lookup");
        Check(leaf.remove_Changed == 479, "reserved-event-remove-name-does-not-hide-field-lookup");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
