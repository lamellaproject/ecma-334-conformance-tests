/*
Rules: E15-11-1-constructor-accessibility; E15-11-1-grammar-constructor-initializer-form-1; E15-11-1-constructor-initializer-invocation; E15-11-1-constructor-initializer-before-body
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: protected internal Gauge(int n)
Into: private Gauge(int n)
*/
using System;
class Gauge { public int N; protected internal Gauge(int n) { N = n + 7; Program.Trace += "B"; } }
class Derived : Gauge { public Derived(int n) : base(n) { N += 5; Program.Trace += "D"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Derived(13);
        Check(item.N == 25, "protected-internal-constructor-value");
        Check(Trace == "BD", "protected-internal-constructor-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
