/*
Rules: E8-3-11-tuple-direct-arities; E8-3-11-tuple-valuetuple-shorthand
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/08-types/generators/tuple-arities.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var tuple = (11, 12, 13, 14, 15);
        System.ValueTuple<int, int, int, int, int> raw = tuple;
        Check(tuple.Item1 == 11 && tuple.Item5 == 15, "arity-5-ordered-fields");
        Check(raw.Item5 == 15, "arity-5-direct-valuetuple");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
