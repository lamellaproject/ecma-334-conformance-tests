/*
Rules: E12-9-3-decimal-negation; E12-9-3-decimal-predefined; E12-9-3-decimal-equivalence
Authority: ECMA-334 7th ed 12.9.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: -positive
Into: +positive
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal positive = 7.125m; decimal negative = -4.75m;
        Check(-positive == -7.125m, "positive"); Check(-negative == 4.75m, "negative");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
