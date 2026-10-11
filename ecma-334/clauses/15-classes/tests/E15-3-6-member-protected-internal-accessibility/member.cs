/*
Rules: E15-3-6-member-protected-internal-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected internal int Read() { return 439; }
Into: protected int Read() { return 439; }
*/
using System;
class Meter { protected internal int Read() { return 439; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter().Read() == 439, "protected-internal-member-accessible-within-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
