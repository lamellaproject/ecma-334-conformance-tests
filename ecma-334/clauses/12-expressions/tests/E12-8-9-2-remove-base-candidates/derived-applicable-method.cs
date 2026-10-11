/*
Rules: E12-8-9-2-remove-base-candidates
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver.Choose(5)
Into: ((Base)receiver).Choose(5)
*/
using System;
class Base { public int Choose(int value) { return 1; } }
class Derived : Base { public int Choose(object value) { return 2; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        Check(receiver.Choose(5) == 2, "applicable-derived-boxing-method-removes-better-base-match");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
