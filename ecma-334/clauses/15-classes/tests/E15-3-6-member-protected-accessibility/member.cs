/*
Rules: E15-3-6-member-protected-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int Number = 443;
Into: private int Number = 443;
*/
using System;
class Parent { protected int Number = 443; }
class Child : Parent { public int Read() { return Number; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Child().Read() == 443, "protected-member-accessible-from-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
