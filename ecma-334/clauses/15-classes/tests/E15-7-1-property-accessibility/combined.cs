/*
Rules: E15-7-1-property-accessibility
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private protected int Inner
Into: private int Inner
*/
using System;
class Base
{
    protected internal int Outer => 12;
    private protected int Inner => 16;
}
class Derived : Base { public int Read() { return Inner; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Base().Outer == 12, "protected-internal-property");
        Check(new Derived().Read() == 16, "private-protected-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
