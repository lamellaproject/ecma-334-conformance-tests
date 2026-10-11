/*
Rules: E15-12-grammar-static-constructor-modifiers-form-3
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static unsafe Gauge()
Into: static Gauge()
*/
using System;
class Gauge { public static int N; static unsafe Gauge() { int n = 13; int* p = &n; N = *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.N == 13, "unsafe-static-constructor-pointer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
