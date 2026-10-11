/*
Rules: E7-7-1-global-member-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: class GlobalItem
Into: class Renamed
*/
using System;
#if FIRST_UNIT
class GlobalItem { public static int Read() { return 41; } }
#elif SECOND_UNIT
namespace Grove { class Probe { public static int Read() { return GlobalItem.Read(); } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(GlobalItem.Read() == 41, "global-type-in-another-compilation-unit");
        Check(Grove.Probe.Read() == 41, "global-type-unqualified-within-a-namespace");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
