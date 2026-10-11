/*
Rules: E15-10-3-right-shift-second-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator >>(Gauge x, int? n) { return n.HasValue ? n.Value + 13 : 7; }
Into: operator >>(Gauge x, int? n) { return n.HasValue ? n.Value + 13 : 8; }
*/
using System;
class Gauge { public static int operator >>(Gauge x, int? n) { return n.HasValue ? n.Value + 13 : 7; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? n = 3;
        Check((new Gauge() >> n) == 16, "nullable-right-shift-second-present");
        n = null;
        Check((new Gauge() >> n) == 7, "nullable-right-shift-second-null-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
