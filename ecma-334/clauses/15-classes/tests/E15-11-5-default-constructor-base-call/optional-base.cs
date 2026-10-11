/*
Rules: E15-11-5-default-constructor-base-call; E15-11-5-default-constructor-supplied
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Gauge : Basis {
Into: class Gauge : Basis { public Gauge() : base(14) { }
*/
using System;
class Basis { public int N; public Basis(int n = 13) { N = n; Program.Trace += "B"; } }
class Gauge : Basis { public int Field = Program.Init("F", 19); }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    public static int Init(string tag, int n) { Trace += tag; return n; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.N == 13 && item.Field == 19, "default-base-optional-argument");
        Check(Trace == "FB", "default-constructor-fields-before-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
