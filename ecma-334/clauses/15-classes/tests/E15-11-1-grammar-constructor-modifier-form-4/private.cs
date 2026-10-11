/*
Rules: E15-11-1-grammar-constructor-modifier-form-4; E15-11-1-constructor-accessibility
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private Gauge(int n) { N = n + 7; }
Into: private Gauge(int n) { N = n + 8; }
*/
using System;
class Gauge { public int N; private Gauge(int n) { N = n + 7; } public static Gauge Create(int n) { return new Gauge(n); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.Create(13).N == 20, "private-constructor-factory");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
