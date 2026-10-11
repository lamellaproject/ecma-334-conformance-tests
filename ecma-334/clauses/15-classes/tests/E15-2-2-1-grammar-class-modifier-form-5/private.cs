/*
Rules: E15-2-2-1-grammar-class-modifier-form-5; E15-2-2-1-access-modifiers
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private class Gauge
Into: public private class Gauge
*/
using System;
class Root
{
    private class Gauge { public int Read() { return 89; } }
    public int Read() { return new Gauge().Read(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Root().Read() == 89, "private-nested-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
