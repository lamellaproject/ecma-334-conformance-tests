/*
Rules: E7-4-1-accessibility-independent-inheritance; E7-4-5-class-inheritance-access; E7-5-3-private-member-inherited; E7-5-3-inherited-private-domain
Authority: ECMA-334 7th ed 7.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Derived : Base
Into: class Derived
*/
using System;
class Base
{
    private int hidden = 31;
    public static int Read(Derived value) { return value.hidden; }
}
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Base.Read(new Derived()) == 31, "inherited-private-field-accessed-inside-declaring-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
