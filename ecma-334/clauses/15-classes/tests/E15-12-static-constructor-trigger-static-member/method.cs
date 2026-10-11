/*
Rules: E15-12-static-constructor-trigger-static-member
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Gauge()
Into: private Gauge()
*/
using System;
class Gauge { static Gauge() { Program.Trace += "C"; } public static int Read() { Program.Trace += "M"; return 13; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Trace == "", "method-trigger-not-earlier");
        int result = Gauge.Read();
        Check(result == 13 && Trace == "CM", "first-method-reference-trigger");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
