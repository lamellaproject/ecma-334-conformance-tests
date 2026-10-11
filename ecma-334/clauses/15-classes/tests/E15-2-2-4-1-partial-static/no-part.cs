/*
Rules: E15-2-2-4-1-partial-static
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial class Gauge { }
Into: static partial class Gauge { }
*/
using System;
partial class Gauge { }
partial class Gauge { public int Read() { return 151; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().Read() == 151, "partial-with-no-static-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
