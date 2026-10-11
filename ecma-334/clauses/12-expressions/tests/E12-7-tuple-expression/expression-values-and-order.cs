/*
Rules: E12-7-tuple-expression; E12-7-definition; E12-7-assignment-purpose
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (first, second) = (Next(3), Next(8));
Into: (first, second) = (Next(8), Next(3));
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next(int value) { trace = trace * 10 + value; return value; }
    static void Main()
    {
        int first = 0, second = 0;
        (first, second) = (Next(3), Next(8));
        Check(trace == 38, "tuple-expression-elements-evaluated-in-source-order");
        Check(first == 3 && second == 8, "deconstruction-assigns-corresponding-expressions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
