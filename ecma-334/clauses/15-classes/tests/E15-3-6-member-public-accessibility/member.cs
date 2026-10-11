/*
Rules: E15-3-6-member-public-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Read() { return 433; }
Into: private int Read() { return 433; }
*/
using System;
class Meter { public int Read() { return 433; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter().Read() == 433, "public-member-accessible-from-unrelated-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
