/*
Rules: E15-10-1-operator-cannot-hide-base-operator
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int operator +(Derived x) { return x.Value + 5; }
Into: int operator +(Derived x) { return x.Value + 6; }
*/
using System;
class Gauge { public int Value = 29; public static int operator +(Gauge x) { return x.Value; } }
class Derived : Gauge { public static int operator +(Derived x) { return x.Value + 5; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived derived = new Derived();
        Gauge basis = derived;
        Check(+derived == 34, "derived-signature-operator");
        Check(+basis == 29, "base-signature-operator-remains");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
