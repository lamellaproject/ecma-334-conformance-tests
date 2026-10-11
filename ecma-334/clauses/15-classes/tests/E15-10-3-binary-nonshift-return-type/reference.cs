/*
Rules: E15-10-3-binary-nonshift-return-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator *(Gauge a, Gauge b)
Into: operator /(Gauge a, Gauge b)
*/
using System;
class Token { public int N = 29; }
class Gauge { public static Token operator *(Gauge a, Gauge b) { return new Token(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token value = new Gauge() * new Gauge();
        Check(value.N == 29, "unrelated-binary-reference-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
