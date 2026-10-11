/*
Rules: E15-7-1-grammar-property-modifier-form-1
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new int Level
Into: override int Level
*/
using System;
class Base { public int Level => 8; }
class Derived : Base { public new int Level => 21; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived item = new Derived();
        Check(item.Level == 21, "new-property");
        Check(((Base)item).Level == 8, "hidden-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
