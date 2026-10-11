/*
Rules: E7-3-base-interface-no-space-contribution; E7-3-inherited-member-name-redeclaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new string Read();
Into: new string Renamed();
*/
using System;
interface Base { int Read(); }
interface Derived : Base { new string Read(); }
class Holder : Derived
{
    int Base.Read() { return 19; }
    public string Read() { return "twig"; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived value = new Holder();
        Check(value.Read() == "twig", "derived-interface-space");
        Check(((Base)value).Read() == 19, "base-interface-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
