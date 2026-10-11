/*
Rules: E12-8-6-positional-name-conflict
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (Item2, other)
Into: (other, Item2)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int Item2 = 3, other = 8;
        var result = (Item2, other);
        Check(result.Item1 == 3, "wrong-position-item-name-is-suppressed");
        Check(result.Item2 == 8, "positional-member-is-not-rebound-to-conflicting-inferred-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
