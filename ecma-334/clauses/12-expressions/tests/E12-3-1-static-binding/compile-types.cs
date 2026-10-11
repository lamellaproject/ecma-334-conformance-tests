/*
Rules: E12-3-1-static-binding; E12-3-1-binding-definition; E12-3-1-method-binding-types; E12-3-1-no-dynamic-static; E12-3-2-static-time; E12-3-2-binding-time-definition; E12-3-4-static-subexpression-type
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Base receiver = new Derived();
Into: Derived receiver = new Derived();
*/
using System;
class Base { public int Choose(object value) { return 1; } }
class Derived : Base { public int Choose(int value) { return 2; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Base receiver = new Derived();
        int result = receiver.Choose(18);
        Check(result == 1, "static-receiver-and-argument-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
