/*
Rules: E15-12-static-initialization-defaults-first; E15-12-static-initialization-field-expressions-second; E15-12-static-initialization-constructor-last
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int First = Probe(); public static int Later = 19;
Into: public static int Later = 19; public static int First = Probe();
*/
using System;
class Gauge
{
    public static int First = Probe(); public static int Later = 19;
    public static object Item = new object();
    public static bool Flag = true;
    public static int Total;
    static int Probe() { Program.Trace += "F"; return Later == 0 && Item == null && !Flag ? 13 : -1; }
    static Gauge() { Total = First + Later; Program.Trace += "C"; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.First == 13, "future-initialized-fields-start-at-defaults");
        Check(Gauge.Later == 19 && Gauge.Item != null && Gauge.Flag, "field-initializers-run-after-defaults");
        Check(Gauge.Total == 32 && Trace == "FC", "constructor-runs-after-field-initializers");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
