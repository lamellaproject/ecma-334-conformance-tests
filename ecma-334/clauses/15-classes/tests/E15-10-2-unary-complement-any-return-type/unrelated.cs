/*
Rules: E15-10-2-unary-complement-any-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: bool operator ~(Gauge x)
Into: bool operator +(Gauge x)
*/
using System;
class Gauge { public static bool operator ~(Gauge x) { return false; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(~new Gauge() == false, "unary-unary-complement-unrelated-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
