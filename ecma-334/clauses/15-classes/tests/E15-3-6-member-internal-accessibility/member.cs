/*
Rules: E15-3-6-member-internal-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal int Read() { return 457; }
Into: private int Read() { return 457; }
*/
using System;
class Meter { internal int Read() { return 457; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter().Read() == 457, "internal-member-accessible-within-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
