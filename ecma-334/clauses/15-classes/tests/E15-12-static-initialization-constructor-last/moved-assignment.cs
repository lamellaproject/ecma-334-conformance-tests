/*
Rules: E15-12-static-initialization-constructor-last
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int N = Initialize(); static Gauge() { Snapshot = N + 7; Program.Trace += "C"; }
Into: public static int N; static Gauge() { Snapshot = N + 7; Program.Trace += "C"; N = Initialize(); }
*/
using System;
class Gauge
{
    public static int Snapshot;
    public static int N = Initialize(); static Gauge() { Snapshot = N + 7; Program.Trace += "C"; }
    static int Initialize() { Program.Trace += "F"; return 13; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.N == 13 && Gauge.Snapshot == 20, "static-constructor-sees-initializer-assignment");
        Check(Trace == "FC", "static-initializer-before-constructor-actions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
