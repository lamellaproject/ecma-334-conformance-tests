/*
Rules: E10-3-2-ed1-unchecked-widening-sign-extension
Authority: ECMA-334 1st ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 6
Diagnostic: none
Mutate: sbyte narrow = -19;
Into: sbyte narrow = 19;
*/
// ECMA-334 1st ed 13.2.1, p. 116 (PDF p. 130), lines 26-29 fixes wider unchecked signed
// bits; the 7th edition's 10.3.2 omits this arm.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    public static int Main()
    {
        sbyte narrow = -19;
        short middle = -527;
        int wide = -65539;
        Check(unchecked((ushort)narrow) == 65517, "sbyte-ushort");
        Check(unchecked((uint)narrow) == 4294967277U, "sbyte-uint");
        Check(unchecked((ulong)narrow) == 18446744073709551597UL, "sbyte-ulong");
        Check(unchecked((uint)middle) == 4294966769U, "short-uint");
        Check(unchecked((ulong)middle) == 18446744073709551089UL, "short-ulong");
        Check(unchecked((ulong)wide) == 18446744073709486077UL, "int-ulong");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
