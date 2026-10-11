/*
Rules: E15-11-1-grammar-constructor-modifier-form-3
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: internal Gauge(int n)
Into: private Gauge(int n)
*/
using System;
class Gauge { public int N; internal Gauge(int n) { N = n + 7; Program.Trace += "B"; } }

class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Check(item.N == 20, "internal-constructor-value");
        Check(Trace == "B", "internal-constructor-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
