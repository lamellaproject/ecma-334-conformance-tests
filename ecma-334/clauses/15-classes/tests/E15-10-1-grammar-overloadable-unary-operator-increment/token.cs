/*
Rules: E15-10-1-grammar-overloadable-unary-operator-increment
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Gauge operator ++(Gauge a)
Into: Gauge operator --(Gauge a)
*/
using System;
class Gauge { public int Value; public Gauge(int n) { Value = n; } public static Gauge operator ++(Gauge a) { return new Gauge(a.Value + (3)); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Gauge old = item++;
        Check(old.Value == 13, "postfix-increment-old");
        Check(item.Value == 16, "postfix-increment-stored");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
