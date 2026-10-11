/*
Rules: E15-3-6-member-private-protected-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private protected int Number = 449;
Into: private int Number = 449;
*/
using System;
class Parent { private protected int Number = 449; }
class Child : Parent { public int Read() { return Number; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Child().Read() == 449, "private-protected-member-accessible-to-derived-class-in-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
