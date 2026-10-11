/*
Rules: E12-8-6-deconstruction-form; E12-8-6-var-form; E12-8-6-deconstruction-tuple-form; E12-8-6-nested-deconstruction-form; E12-8-6-identifier-deconstruction-form; E12-8-6-deconstruction-shorthand; E12-8-6-deconstruction-recursion; E12-8-6-deconstruction-identifiers
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: var (first, (middle, last))
Into: var (last, (middle, first))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsInt(int value) { return true; }
    static bool IsInt(object value) { return false; }
    static void Main()
    {
        var (first, (middle, last)) = (3, (8, 9));
        Check(first == 3, "outer-deconstruction-identifier-declares-first-value");
        Check(middle == 8, "nested-deconstruction-identifier-declares-middle-value");
        Check(last == 9, "recursive-deconstruction-identifier-declares-last-value");
        Check(IsInt(first) && IsInt(middle) && IsInt(last), "shorthand-infers-each-declaration-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
