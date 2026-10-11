/*
Rules: E7-3-partial-type-repetition; E7-3-partial-type-aggregation; E7-3-partial-type-space; E7-3-type-declaration-categories
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial interface Joined { int Second(); }
Into: partial interface Renamed { int Second(); }
*/
using System;
partial interface Joined { int First(); }
partial interface Joined { int Second(); }
class Implementation : Joined
{
    public int First() { return 11; }
    public int Second() { return 13; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Joined item = new Implementation();
        Check(item.First() == 11, "first-interface-part");
        Check(item.Second() == 13, "second-interface-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
