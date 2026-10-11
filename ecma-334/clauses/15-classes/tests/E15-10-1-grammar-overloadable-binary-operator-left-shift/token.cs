/*
Rules: E15-10-1-grammar-overloadable-binary-operator-left-shift; E15-10-1-grammar-operator-declarator-form-2; E15-10-1-grammar-binary-operator-declarator
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int operator <<(Gauge a, int n)
Into: int operator >>(Gauge a, int n)
*/
using System;
class Gauge { public int Value; public Gauge(int n) { Value = n; } public static int operator <<(Gauge a, int n) { return a.Value << n; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge a = new Gauge(13);
        Check((a << 1) == 26, "binary-left-shift");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
