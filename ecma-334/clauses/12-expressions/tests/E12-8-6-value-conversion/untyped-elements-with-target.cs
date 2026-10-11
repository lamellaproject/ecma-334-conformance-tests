/*
Rules: E12-8-6-value-conversion; E12-8-6-classification
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (3, () => 8)
Into: (3, () => 9)
*/
using System;
delegate int Pick();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        (long, Pick) result = (3, () => 8);
        Check(result.Item1 == 3L, "tuple-target-converts-typed-element");
        Check(result.Item2() == 8, "tuple-target-converts-untyped-anonymous-function");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
