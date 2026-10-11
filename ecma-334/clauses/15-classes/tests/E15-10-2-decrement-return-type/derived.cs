/*
Rules: E15-10-2-decrement-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator --(Gauge x) { return new Derived(x.N + (-7)); }
Into: operator --(Gauge x) { return new Derived(x.N + (-6)); }
*/
using System;
class Gauge { public int N; public Gauge(int n) { N = n; } public static Derived operator --(Gauge x) { return new Derived(x.N + (-7)); } }
class Derived : Gauge { public Derived(int n) : base(n) { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(20);
        Gauge result = --item;
        Check(item.N == 13 && result.N == 13, "derived-decrement-value");
        Check(item is Derived && object.ReferenceEquals(item, result), "derived-decrement-result-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
