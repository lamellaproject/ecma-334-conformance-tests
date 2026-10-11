/*
Rules: E15-10-3-binary-nonshift-containing-parameter
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator *(int n, Gauge x)
Into: operator /(int n, Gauge x)
*/
using System;
class Gauge { public int N = 13; public static int operator *(int n, Gauge x) { return n + x.N; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(3 * new Gauge() == 16, "containing-type-right-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
