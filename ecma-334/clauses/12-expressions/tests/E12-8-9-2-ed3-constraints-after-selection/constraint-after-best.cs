/*
Rules: E12-8-9-2-ed3-constraints-after-selection
Authority: ECMA-334 3rd ed 14.5.5.1
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-8-9-2-ed3-constraints-after-selection/constraint-after-best.cs.part
Mutate: Choose(seed)
Into: Choose((object)seed)
*/
// ECMA-334 3rd ed 14.5.5.1, p. 170 (PDF p. 190).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Choose<T>(T value) where T : struct { return 1; }
    static int Choose(object value) { return 2; }
    static int Main()
    {
        string seed = "flint";
        int value = Choose(seed);
        Check(value == 2, "constraint-selection");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
