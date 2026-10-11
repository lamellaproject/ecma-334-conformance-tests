/*
Rules: E15-2-2-1-grammar-class-modifier-form-3; E15-2-2-1-access-modifiers
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected class Gauge
Into: private class Gauge
*/
using System;
class Root { protected class Gauge { public int Read() { return 79; } } }
class Leaf : Root { public int Read() { return new Gauge().Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Leaf().Read() == 79, "protected-nested-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
