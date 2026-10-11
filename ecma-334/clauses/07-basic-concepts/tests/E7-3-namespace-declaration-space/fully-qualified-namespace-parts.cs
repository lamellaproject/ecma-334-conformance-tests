/*
Rules: E7-3-namespace-declaration-space
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: public static int Later() { return 29; }
Into: public static int Different() { return 29; }
*/
using System;
#if FIRST_UNIT
namespace Grove.Leaf { partial class Joined { public static int Earlier() { return Later() + 1; } } }
#elif SECOND_UNIT
namespace Grove { namespace Leaf { partial class Joined { public static int Later() { return 29; } } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Grove.Leaf.Joined.Earlier() == 30, "qualified-namespace-space-across-units");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
