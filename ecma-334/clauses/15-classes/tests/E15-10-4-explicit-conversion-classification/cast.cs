/*
Rules: E15-10-4-explicit-conversion-classification
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: explicit operator int(Gauge x) { Program.Calls++; return x.N + 6; }
Into: explicit operator int(Gauge x) { Program.Calls++; return x.N + 7; }
*/
using System;
class Gauge { public int N = 13; public static explicit operator int(Gauge x) { Program.Calls++; return x.N + 6; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)new Gauge() == 19, "explicit-cast-result");
        Check(Calls == 1, "explicit-conversion-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
