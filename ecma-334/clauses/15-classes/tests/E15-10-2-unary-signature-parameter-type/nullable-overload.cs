/*
Rules: E15-10-2-unary-signature-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator +(Gauge? x)
Into: operator +(Gauge x)
*/
using System;
struct Gauge { public static int operator +(Gauge x) { return 13; } public static int operator +(Gauge? x) { return 19; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(+new Gauge() == 13, "nonnullable-signature");
        Check(+(Gauge?)new Gauge() == 19, "nullable-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
