/*
Rules: E15-10-2-unary-plus-any-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string operator +(Gauge x)
Into: string operator -(Gauge x)
*/
using System;
class Gauge { public static string operator +(Gauge x) { return "value"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(+new Gauge() == "value", "unary-unary-plus-unrelated-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
