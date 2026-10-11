/*
Rules: E15-2-2-1-grammar-class-modifier-form-1; E15-2-2-1-nested-new; E15-2-2-1-new-hides
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new class Gauge
Into: public override class Gauge
*/
using System;
class Root { public class Gauge { public int Read() { return 67; } } }
class Leaf : Root { public new class Gauge { public int Read() { return 71; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Root.Gauge().Read() == 67, "base-nested-name");
        Check(new Leaf.Gauge().Read() == 71, "new-nested-name-hides");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
