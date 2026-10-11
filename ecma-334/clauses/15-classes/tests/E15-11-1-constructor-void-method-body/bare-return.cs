/*
Rules: E15-11-1-constructor-void-method-body
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if (n < 0) return;
Into: if (n < 0) return 7;
*/
using System;
class Gauge { public int N; public Gauge(int n) { N = 13; if (n < 0) return; N = n; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge(-1).N == 13, "constructor-bare-return-path");
        Check(new Gauge(19).N == 19, "constructor-reachable-end-path");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
