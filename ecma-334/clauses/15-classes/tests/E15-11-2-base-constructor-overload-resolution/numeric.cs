/*
Rules: E15-11-2-base-constructor-overload-resolution
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: : base(3L)
Into: : base(3)
*/
using System;
class Basis { public int N; public Basis(int n) { N = 13; } public Basis(long n) { N = 19; } }
class Gauge : Basis { public Gauge() : base(3L) { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().N == 19, "base-long-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
