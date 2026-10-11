/*
Rules: E12-2-1-tuple-arity; E12-2-1-tuple-elements; E12-2-2-tuple-value
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (first: 8, 13)
Into: (first: 8, 13, 21)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        (long first, long last) pair = (first: 8, 13);
        Check(pair.first == 8L, "named-tuple-value");
        Check(pair.last == 13L, "tuple-converted-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
