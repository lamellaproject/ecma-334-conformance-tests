/*
Rules: E15-11-1-grammar-constructor-initializer-form-2; E15-11-1-constructor-initializer-before-body; E15-11-1-constructor-initializer-invocation
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: : this(13)
Into: : this(14)
*/
using System;
class Gauge
{
    public int N;
    public Gauge() : this(13) { N += 5; Program.Trace += "D"; }
    private Gauge(int n) { N = n + 7; Program.Trace += "T"; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.N == 25, "this-initializer-value");
        Check(Trace == "TD", "this-initializer-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
