/*
Rules: E8-3-11-large-tuple-rest-representation; E8-3-11-tuple-matching-arity-not-required; E8-3-11-tuple-nesting-observability; E8-3-11-tuple-valuetuple-shorthand
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
        var tuple = (11, 12, 13, 14, 15, 16, 17, 18, 19);
        Check(tuple.Item1 == 11 && tuple.Item9 == 19, "arity-9-ordered-fields");
        Check(tuple.Rest.Item2 == 19, "arity-9-nested-rest");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
