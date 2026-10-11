/*
Rules: E15-2-2-2-partial-abstract
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial class Gauge { }
Into: abstract partial class Gauge { }
*/
using System;
partial class Gauge { }
partial class Gauge { public int Read() { return 131; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().Read() == 131, "partial-with-no-abstract-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
