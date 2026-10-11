/*
Rules: E12-8-6-inferred-element-name
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (source?.alpha, source?.beta)
Into: (source?.alpha + 0, source?.beta)
*/
using System;
class Pair { public int alpha = 3, beta = 8; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair source = new Pair();
        var result = (source?.alpha, source?.beta);
        Check(result.alpha == 3 && result.beta == 8, "conditional-member-names-become-tuple-element-names");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
