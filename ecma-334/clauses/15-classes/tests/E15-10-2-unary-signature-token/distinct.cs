/*
Rules: E15-10-2-unary-signature-token
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator -(Gauge x) { return 19; }
Into: operator +(Gauge x) { return 19; }
*/
using System;
class Gauge { public static int operator +(Gauge x) { return 13; } public static int operator -(Gauge x) { return 19; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(+item == 13, "plus-signature");
        Check(-item == 19, "minus-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
