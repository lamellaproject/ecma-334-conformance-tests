/*
Rules: E8-3-11-tuple-ordered-sequence; E8-3-11-tuple-arity-definition; E8-3-11-tuple-optional-names; E8-3-11-tuple-expression-creation; E8-3-11-tuple-item-fields; E8-3-11-tuple-item-access; E8-3-11-tuple-named-access; E8-3-1-struct-form-tuple; E8-3-1-tuple-form; E8-3-1-tuple-element-form
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (int count, string) tuple = (39, "packet");
Into: (int count, string) tuple = (40, "packet");
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        (int count, string) tuple = (39, "packet");
        tuple.Item2 = "changed";
        Check(tuple.count == 39 && tuple.Item1 == 39 && tuple.Item2 == "changed", "ordered-named-and-unnamed-elements");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
