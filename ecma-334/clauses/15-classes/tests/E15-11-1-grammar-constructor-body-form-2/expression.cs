/*
Rules: E15-11-1-grammar-constructor-body-form-2; E15-11-1-constructor-expression-initialization; E15-11-1-constructor-void-method-body
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: => Initialize(n);
Into: => Initialize(n + 1);
*/
using System;
class Gauge { public int N; public Gauge(int n) => Initialize(n); void Initialize(int n) { N = n + 7; Program.Trace += "E"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Check(item.N == 20, "constructor-expression-value");
        Check(Trace == "E", "constructor-expression-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
