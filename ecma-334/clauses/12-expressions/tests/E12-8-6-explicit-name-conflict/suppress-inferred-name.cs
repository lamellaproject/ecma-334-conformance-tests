/*
Rules: E12-8-6-explicit-name-conflict; E12-8-6-explicit-element-name; E12-8-6-unnamed-type-element
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (named: 3, source.named)
Into: (3, source.named)
*/
using System;
class Pair { public int named = 8; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair source = new Pair();
        var result = (named: 3, source.named);
        Check(result.named == 3, "explicit-name-retained-instead-of-conflicting-inferred-name");
        Check(result.Item2 == 8, "conflicting-inferred-element-retains-positional-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
