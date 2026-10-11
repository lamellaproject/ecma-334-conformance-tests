/*
Rules: E12-8-6-value-deconstructing-assignment
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (first, second) = (3, 8)
Into: (second, first) = (3, 8)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = 0, second = 0;
        var result = ((first, second) = (3, 8));
        Check(first == 3 && second == 8, "deconstructing-assignment-writes-tuple-target");
        Check(result.Item1 == 3 && result.Item2 == 8, "deconstructing-assignment-produces-tuple-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
