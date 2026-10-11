/*
Rules: E11-2-2-declaration-discard; E11-2-2-declaration-discard-hides-name
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is int _
Into: source is long _
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int _ = 41;
        object source = 29;
        bool matched = source is int _;
        Check(matched, "matched-discard");
        Check(_ == 41, "named-underscore-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
