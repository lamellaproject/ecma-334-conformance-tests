/*
Rules: E7-3-partial-type-repetition; E7-3-partial-type-aggregation; E7-3-partial-type-space; E7-3-type-declaration-categories
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Second() { return 5; }
Into: public int Renamed() { return 5; }
*/
using System;
partial struct Joined { public int First() { return Second() + 2; } }
partial struct Joined { public int Second() { return 5; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Joined().First() == 7, "partial-struct-merged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
