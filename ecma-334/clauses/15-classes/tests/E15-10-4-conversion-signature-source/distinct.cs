/*
Rules: E15-10-4-conversion-signature-source
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator Gauge(string x)
Into: operator Gauge(int x)
*/
using System;
class Gauge { public int N; public Gauge(int n) { N = n; } public static implicit operator Gauge(int x) { return new Gauge(13); } public static implicit operator Gauge(string x) { return new Gauge(19); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge first = 3;
        Gauge second = "coil";
        Check(first.N == 13, "conversion-int-source-signature");
        Check(second.N == 19, "conversion-string-source-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
