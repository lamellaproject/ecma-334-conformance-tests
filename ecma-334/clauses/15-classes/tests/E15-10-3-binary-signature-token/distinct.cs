/*
Rules: E15-10-3-binary-signature-token
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator /(Gauge a, Gauge b)
Into: operator *(Gauge a, Gauge b)
*/
using System;
class Gauge { public static int operator *(Gauge a, Gauge b) { return 13; } public static int operator /(Gauge a, Gauge b) { return 19; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge a = new Gauge();
        Gauge b = new Gauge();
        Check(a * b == 13, "multiply-signature");
        Check(a / b == 19, "divide-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
