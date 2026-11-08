/*
Rules: E15-10-3-ed3-shift-count-int-required
Authority: ECMA-334 3rd ed 17.9.2
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E15-10-3-ed3-shift-count-int-required/right-count.cs.part
Mutate: int? distance
Into: int distance
*/
// ECMA-334 3rd ed 17.9.2, p. 315 (PDF p. 335).
using System;
class Measure
{
    public static Measure operator >>(Measure value, int? distance)
    {
        return value;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Measure value = new Measure();
        Check((value >> 3) == value, "right-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
