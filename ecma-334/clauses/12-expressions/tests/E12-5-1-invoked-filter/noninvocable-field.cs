/*
Rules: E12-5-1-invoked-filter; E12-5-1-invoked-definition
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver.Pick(3)
Into: receiver.Pick
*/
using System;
class Base { public int Pick(int value) { return value + 10; } }
class Derived : Base { public new int Pick = 47; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived(); int result = receiver.Pick(3);
        Check(result == 13, "invoked-removes-noninvocable-field");
        Check(receiver.Pick == 47, "noninvoked-retains-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
