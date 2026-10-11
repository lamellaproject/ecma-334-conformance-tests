/*
Rules: E15-11-2-constructor-parameter-initializer-scope; E15-11-2-initializer-parameter-access
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: : base(++n, n)
Into: : base(n++, n)
*/
using System;
class Basis { public int A, B; public Basis(int a, int b) { A = a; B = b; } }
class Gauge : Basis { public int N; public Gauge(int n) : base(++n, n) { N = n; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Check(item.A == 14, "initializer-parameter-preincrement");
        Check(item.B == 14 && item.N == 14, "initializer-parameter-update-order-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
