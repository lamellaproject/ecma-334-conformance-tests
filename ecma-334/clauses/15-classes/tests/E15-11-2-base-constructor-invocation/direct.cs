/*
Rules: E15-11-2-base-constructor-invocation; E15-11-2-constructor-chaining-required
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: : base(13)
Into: : base(14)
*/
using System;
class Root { public int N; public Root(int n) { N = n; Program.Trace += "R"; } }
class Basis : Root { public Basis(int n) : base(n + 7) { N += 5; Program.Trace += "B"; } }
class Gauge : Basis { public Gauge() : base(13) { N += 3; Program.Trace += "D"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.N == 28, "direct-base-constructor-invocation");
        Check(Trace == "RBD", "constructor-chain-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
