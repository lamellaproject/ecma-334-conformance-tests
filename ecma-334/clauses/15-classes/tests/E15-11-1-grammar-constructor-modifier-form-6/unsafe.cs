/*
Rules: E15-11-1-grammar-constructor-modifier-form-6
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe Gauge()
Into: public Gauge()
*/
using System;
class Gauge { public int N; public unsafe Gauge() { int n = 13; int* pointer = &n; N = *pointer; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().N == 13, "unsafe-constructor-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
