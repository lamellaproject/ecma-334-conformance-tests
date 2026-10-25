/*
Rules: E10-3-2-ed1-checked-floating-source-range
Authority: ECMA-334 1st ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 4
Version-Witness: tests/E10-3-2-ed1-checked-floating-source-range/checked-source-range.witness.cs.part
Mutate: return checked((byte)value);
Into: return unchecked((byte)value);
*/
// ECMA-334 1st ed 13.2.1, p. 116 (PDF p. 130), lines 35-41. In a checked
// floating-to-integral conversion, the source value is compared with the destination range
// before rounding toward zero.
using System;

class Entry
{
    static int checks;
    static int failures;

    static byte ToByte(double value)
    {
        return checked((byte)value);
    }

    static bool Overflows(double value)
    {
        try { ToByte(value); return false; }
        catch (OverflowException) { return true; }
    }

    static bool Truncates(double value, byte expected)
    {
        try { return ToByte(value) == expected; }
        catch (OverflowException) { return false; }
    }

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
        Check(Overflows(255.75), "upper-fraction");
        Check(Overflows(-0.75), "lower-fraction");
        Check(Truncates(254.75, 254), "inside-truncation");
        Check(Overflows(257.0), "outside-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
