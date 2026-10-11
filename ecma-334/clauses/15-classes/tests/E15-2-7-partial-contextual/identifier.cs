/*
Rules: E15-2-7-partial-contextual
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class partial { public int Number = 61; }
Into: class Symbol { public int Number = 61; }
*/
using System;
class partial { public int Number = 61; }
class Meter { public int partial = 67; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        partial partial = new partial();
        Check(partial.Number == 61, "partial-type-and-local-identifiers");
        Check(new Meter().partial == 67, "partial-member-identifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
