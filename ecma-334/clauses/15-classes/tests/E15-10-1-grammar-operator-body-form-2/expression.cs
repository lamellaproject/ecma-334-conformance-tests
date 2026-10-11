/*
Rules: E15-10-1-grammar-operator-body-form-2; E15-10-1-operator-expression-execution
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: => Observe(x.Value)
Into: => x.Value
*/
using System;
class Gauge
{
    public int Value = 7;
    static int Observe(int n) { Program.Trace += "E"; return n + 5; }
    public static int operator +(Gauge x) => Observe(x.Value);
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(+new Gauge() == 12, "expression-operator-value");
        Check(Trace == "E", "expression-operator-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
