/*
Rules: E15-11-1-grammar-constructor-declaration
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Gauge(int n) { N = n + 7; }
Into: Gauge(int n) { N = n + 8; }
*/
using System;
class Gauge { public int N; Gauge(int n) { N = n + 7; } public static Gauge Create(int n) { return new Gauge(n); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.Create(13).N == 20, "implicit-private-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
