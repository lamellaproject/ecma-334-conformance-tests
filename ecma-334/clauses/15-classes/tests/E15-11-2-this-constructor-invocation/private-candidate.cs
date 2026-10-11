/*
Rules: E15-11-2-this-constructor-invocation; E15-11-2-this-constructor-candidate-set; E15-11-2-this-constructor-overload-resolution
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private Gauge(int n)
Into: private Gauge(string n)
*/
using System;
class Gauge
{
    public int N;
    public Gauge() : this(3) { N += 5; Program.Trace += "D"; }
    private Gauge(int n) { N = 13; Program.Trace += "I"; }
    public Gauge(long n) { N = 19; Program.Trace += "L"; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.N == 18, "this-private-overload-selected");
        Check(Trace == "ID", "this-constructor-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
