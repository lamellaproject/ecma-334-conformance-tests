/*
Rules: E15-10-1-grammar-overloadable-binary-operator-or; E15-10-1-grammar-operator-declarator-form-2; E15-10-1-grammar-binary-operator-declarator
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int operator |(Gauge a, Gauge b)
Into: int operator +(Gauge a, Gauge b)
*/
using System;
class Gauge { public int Value; public Gauge(int n) { Value = n; } public static int operator |(Gauge a, Gauge b) { return a.Value | b.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge a = new Gauge(13);
        Check((a | new Gauge(5)) == 13, "binary-or");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
