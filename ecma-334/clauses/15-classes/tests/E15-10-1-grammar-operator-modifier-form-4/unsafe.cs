/*
Rules: E15-10-1-grammar-operator-modifier-form-4
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe int operator +(Gauge x)
Into: int operator +(Gauge x)
*/
using System;
class Gauge
{
    public static unsafe int operator +(Gauge x) { int n = 19; int* p = &n; return *p; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(+new Gauge() == 19, "unsafe-operator-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
