/*
Rules: E15-12-static-constructor-void-method-body
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: if (Program.Early) return;
Into: if (Program.Early) return 7;
*/
using System;
class Gauge { public static int N; static Gauge() { N = 13; if (Program.Early) return; N = 19; } }
class Program
{
    static int checks, failures;
    public static bool Early;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Early = true;
        Check(Gauge.N == 13, "static-constructor-bare-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
