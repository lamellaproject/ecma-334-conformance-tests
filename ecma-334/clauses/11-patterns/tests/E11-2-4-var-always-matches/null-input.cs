/*
Rules: E11-2-4-var-always-matches; E11-2-4-var-all-types
Authority: ECMA-334 7th ed 11.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is var value
Into: source is object value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = null;
        bool matched = source is var value;
        Check(matched, "null-still-matches");
        Check(value == null, "null-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
