/*
Rules: E15-10-2-unary-minus-any-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Token operator -(Gauge x)
Into: Token operator +(Gauge x)
*/
using System;
class Token { }
class Gauge { public static Token operator -(Gauge x) { return new Token(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((-new Gauge()) is Token, "unary-unary-minus-unrelated-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
