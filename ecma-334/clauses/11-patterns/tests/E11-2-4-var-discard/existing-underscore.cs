/*
Rules: E11-2-4-var-discard; E11-2-4-var-discard-hides-name
Authority: ECMA-334 7th ed 11.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is var _
Into: source is int _
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int _ = 41;
        object source = null;
        bool matched = source is var _;
        Check(matched, "null-discard-matches");
        Check(_ == 41, "named-underscore-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
