/*
Rules: E15-3-1-static-constructor-category; E15-3-1-grammar-class-member-declaration-form-10
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Registry() { Number = 163; Calls++; }
Into: static Registry() { }
*/
using System;
class Registry
{
    public static int Number, Calls;
    static Registry() { Number = 163; Calls++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Registry.Number == 163, "static-constructor-initializes-class");
        Check(Registry.Calls == 1, "static-constructor-action-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
