/*
Rules: E7-3-base-class-no-space-contribution; E7-3-inherited-member-name-redeclaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new string Member = "leaf";
Into: public new string Different = "leaf";
*/
using System;
class Base { public int Member = 17; }
class Derived : Base { public new string Member = "leaf"; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Derived();
        Check(value.Member == "leaf", "derived-declaration-space-member");
        Check(((Base)value).Member == 17, "base-member-still-exists");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
