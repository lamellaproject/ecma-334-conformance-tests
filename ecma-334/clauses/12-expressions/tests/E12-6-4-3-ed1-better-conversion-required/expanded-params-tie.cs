/*
Rules: E12-6-4-3-ed1-better-conversion-required
Authority: ECMA-334 1st ed 14.4.2.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-6-4-3-ed1-better-conversion-required/expanded-params-tie.witness.cs.part
Mutate: Route(18, 23)
Into: Route(new int[] {18, 23})
*/
// ECMA-334 1st ed 14.4.2.2, p. 136 (PDF p. 150), lines 1-5. A function member is better
// only with at least one strictly better argument conversion.
using System;
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
    static int Route(params int[] values) { return values[0] + values[1]; }
    static int Route(int first, params int[] values) { return first + values[0]; }
    static int Main()
    {
        Check(Route(18, 23) == 41, "explicit-array-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
