/*
Rules: E12-8-6-inferred-element-name
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (alpha, beta)
Into: (alpha + 0, beta)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int alpha = 3, beta = 8;
        var result = (alpha, beta);
        Check(result.alpha == 3 && result.beta == 8, "simple-expression-names-become-tuple-element-names");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
