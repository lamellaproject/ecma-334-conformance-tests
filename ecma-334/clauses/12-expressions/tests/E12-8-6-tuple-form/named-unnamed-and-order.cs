/*
Rules: E12-8-6-tuple-form; E12-8-6-element-form; E12-8-6-classification; E12-8-6-type-existence; E12-8-6-type-arity; E12-8-6-explicit-element-name; E12-8-6-unnamed-type-element; E12-8-6-element-order; E12-8-6-value-reclassification; E12-8-1-tuple-form
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (first: Next(3), Next(8), last: Next(9))
Into: (first: Next(5), Next(8), last: Next(9))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next(int value) { trace = trace * 10 + value; return value; }
    static void Main()
    {
        var result = (first: Next(3), Next(8), last: Next(9));
        Check(trace == 389, "tuple-elements-evaluated-left-to-right");
        Check(result.first == 3 && result.Item2 == 8 && result.last == 9, "tuple-type-retains-arity-and-element-names");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
