/*
Rules: E15-10-2-unary-not-any-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal operator !(Gauge x)
Into: decimal operator +(Gauge x)
*/
using System;
class Gauge { public static decimal operator !(Gauge x) { return 19m; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(!new Gauge() == 19m, "unary-unary-not-unrelated-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
