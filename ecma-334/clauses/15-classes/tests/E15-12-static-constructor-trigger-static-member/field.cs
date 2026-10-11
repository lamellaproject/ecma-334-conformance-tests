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
class Gauge { public static int N; static Gauge() { N = 13; Program.Calls++; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Calls == 0, "field-trigger-not-earlier");
        int result = Gauge.N;
        Check(result == 13 && Calls == 1, "first-field-reference-trigger");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
