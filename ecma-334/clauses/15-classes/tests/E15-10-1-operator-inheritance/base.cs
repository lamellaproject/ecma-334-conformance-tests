/*
Rules: E15-10-1-operator-inheritance
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int operator +(Gauge x)
Into: int operator -(Gauge x)
*/
using System;
class Gauge { public int Value = 29; public static int operator +(Gauge x) { return x.Value; } }
class Derived : Gauge { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(+new Derived() == 29, "inherited-unary-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
