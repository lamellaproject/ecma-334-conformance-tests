/*
Rules: E15-11-5-default-constructor-supplied; E15-11-5-default-constructor-base-call
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Gauge : Basis {
Into: class Gauge : Basis { public Gauge(int n) { }
*/
using System;
abstract class Basis { public int N = Program.Init("B", 13); }
class Gauge : Basis { public int More = Program.Init("D", 19); }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    public static int Init(string tag, int n) { Trace += tag; return n; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.N == 13 && item.More == 19, "derived-default-invokes-abstract-base-default");
        Check(Trace == "DB", "derived-and-abstract-base-default-initializers");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
