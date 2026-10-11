/*
Rules: E15-10-1-operator-parameter-modifier-limit
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int operator +(in Gauge x)
Into: int operator -(in Gauge x)
*/
using System;
class Gauge { public int Value = 23; public static int operator +(in Gauge x) { return x.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(+item == 23, "operator-in-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
