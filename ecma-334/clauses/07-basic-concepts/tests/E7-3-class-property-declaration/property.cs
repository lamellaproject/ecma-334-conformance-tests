/*
Rules: E7-3-class-property-declaration; E7-3-setter-value-parameter; E7-4-5-class-property-declaration; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: set { stored = value; }
Into: set { stored = 0; }
*/
using System;
class Holder
{
    int stored;
    public int Value { get { return stored; } set { stored = value; } }
}
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var item = new Derived();
        item.Value = 31;
        Check(item.Value == 31, "property-accessors-and-value-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
