/*
Rules: E11-2-4-var-assignment; E11-2-4-var-local; E11-2-4-grammar-var-pattern-1; E11-2-4-grammar-designation-1; E11-2-1-grammar-pattern-3
Authority: ECMA-334 7th ed 11.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: input is var value
Into: input is string value
*/
using System;
class Program
{
    static int checks, failures;
    static int Which(object value) { return 1; }
    static int Which(string value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object input = "harbor";
        bool matched = input is var value;
        Check(matched && object.ReferenceEquals(value, input), "assigned-identity");
        Check(Which(value) == 1, "static-input-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
