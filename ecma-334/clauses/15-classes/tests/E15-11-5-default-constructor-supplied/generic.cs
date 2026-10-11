/*
Rules: E15-11-5-default-constructor-supplied
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Gauge<T> {
Into: class Gauge<T> { public Gauge(int n) { N = n; }
*/
using System;
class Gauge<T> { public int N = 13; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge<int>().N == 13, "generic-class-default-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
