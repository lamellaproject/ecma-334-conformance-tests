/*
Rules: E15-2-2-4-2-static-member-qualifier
Authority: ECMA-334 7th ed 15.2.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Gauge.Read()
Into: Read()
*/
using System;
static class Gauge { public static int Read() { return 163; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.Read() == 163, "static-class-member-qualification");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
