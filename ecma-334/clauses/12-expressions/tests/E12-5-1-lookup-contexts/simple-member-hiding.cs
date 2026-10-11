/*
Rules: E12-5-1-lookup-contexts; E12-5-1-lookup-definition; E12-5-1-hide-base-members; E12-5-1-single-nonmethod; E12-5-1-single-inheritance-unambiguous; E12-5-1-single-inheritance-hiding
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Value = 41;
Into: public int Other = 41;
*/
using System;
class Base { public int Value = 13; }
class Derived : Base
{
    public new int Value = 41;
    public int Read() { return Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        Check(receiver.Value == 41, "member-access-hides-base-field");
        Check(receiver.Read() == 41, "simple-name-hides-base-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
