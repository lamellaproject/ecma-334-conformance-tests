/*
Rules: E12-5-1-method-hides-nonmethods
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver.Pick()
Into: ((Base)receiver).Pick
*/
using System;
class Base { public int Pick = 13; }
class Derived : Base { public new int Pick() { return 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived(); int result = receiver.Pick();
        Check(result == 23, "method-hides-base-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
