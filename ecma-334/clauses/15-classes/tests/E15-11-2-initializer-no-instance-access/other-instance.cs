/*
Rules: E15-11-2-initializer-no-instance-access
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: base(new Other(n).N)
Into: base(new Other(n + 1).N)
*/
using System;
class Other { public int N; public Other(int n) { N = n + 7; Program.Trace += "O"; } }
class Basis { public int N; public Basis(int n) { N = n; Program.Trace += "B"; } }
class Gauge : Basis { public Gauge(int n) : base(new Other(n).N) { Program.Trace += "D"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge(13);
        Check(item.N == 20, "initializer-can-access-other-instance");
        Check(Trace == "OBD", "initializer-argument-before-base-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
