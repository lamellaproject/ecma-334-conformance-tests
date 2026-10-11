/*
Rules: E7-3-global-declaration-space; E7-3-partial-type-repetition; E7-3-partial-type-aggregation; E7-3-partial-type-space
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: public static int Later() { return 23; }
Into: public static int Different() { return 23; }
*/
using System;
#if FIRST_UNIT
partial class Joined { public static int Earlier() { return Later() + 1; } }
#elif SECOND_UNIT
partial class Joined { public static int Later() { return 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Joined.Earlier() == 24, "member-resolved-across-units");
        Check(Joined.Later() == 23, "one-global-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
