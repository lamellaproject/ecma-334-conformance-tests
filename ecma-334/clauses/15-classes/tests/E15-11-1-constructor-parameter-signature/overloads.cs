/*
Rules: E15-11-1-constructor-parameter-signature; E15-11-1-constructor-overload-selection
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Gauge(long n)
Into: Gauge(int n)
*/
using System;
class Gauge { public int N; public Gauge(int n) { N = 13; } public Gauge(long n) { N = 19; } public Gauge(string n) { N = 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge((short)3).N == 13, "constructor-numeric-overload");
        Check(new Gauge(3L).N == 19, "constructor-long-overload");
        Check(new Gauge("coil").N == 23, "constructor-string-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
