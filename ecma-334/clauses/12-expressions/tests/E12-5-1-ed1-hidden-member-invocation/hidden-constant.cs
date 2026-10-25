/*
Rules: E12-5-1-ed1-hidden-member-invocation
Authority: ECMA-334 1st ed 14.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-5-1-ed1-hidden-member-invocation/hidden-constant.witness.cs.part
Mutate: Gauge.Read()
Into: Meter.Read()
*/
// ECMA-334 1st ed 14.3, p. 129 (PDF p. 143), lines 18-31. A derived non-delegate field,
// property or constant, or a nested type, hides all base members of that name before
// invocation is checked.
using System;
class Meter
{
    public static int Read() { return 42; }
}
class Gauge : Meter
{
    public new const int Read = 9;
}
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Main()
    {
        Check(Gauge.Read() == 42, "base-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
