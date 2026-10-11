/*
Rules: E15-10-3-paired-return-types-match; E15-10-3-paired-parameter-types-match
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Number operator <(Gauge a, Number b)
Into: long operator <(Gauge a, Number b)
*/
using System;
using Number = System.Int32;
class Gauge { public static int operator >(Gauge a, int b) { return 13; } public static Number operator <(Gauge a, Number b) { return 19; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check((item > 3) == 13, "alias-identity-pair-result");
        Check((item < 3) == 19, "alias-identity-pair-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
