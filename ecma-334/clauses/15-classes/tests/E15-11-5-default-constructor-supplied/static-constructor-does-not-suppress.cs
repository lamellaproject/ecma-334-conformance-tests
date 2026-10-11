/*
Rules: E15-11-5-default-constructor-supplied
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Gauge()
Into: private Gauge()
*/
using System;
class Gauge { public int N = 13; static Gauge() { Program.Trace += "S"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    public static int Init(string tag, int n) { Trace += tag; return n; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.N == 13, "default-instance-constructor-with-static-constructor");
        Check(Trace == "S", "separate-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
