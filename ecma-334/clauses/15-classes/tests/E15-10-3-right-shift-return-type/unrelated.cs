/*
Rules: E15-10-3-right-shift-return-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string operator >>(Gauge x, int n)
Into: string operator <<(Gauge x, int n)
*/
using System;
class Gauge { public static string operator >>(Gauge x, int n) { return "shift"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((new Gauge() >> 3) == "shift", "unrelated-right-shift-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
