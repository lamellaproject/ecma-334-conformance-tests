/*
Rules: E12-9-5-ed1-enum-complement-context
Authority: ECMA-334 1st ed 14.6.4
Version: ISO-1
Expected: run
Stdout: OK 3
Version-Witness: tests/E12-9-5-ed1-enum-complement-context/checked-ushort-complement.witness.cs.part
Mutate: checked(~value) == value
Into: unchecked(~value) == value
*/
// ECMA-334 1st ed 14.6.4, p. 155 (PDF p. 169), lines 33-36. Enum complement follows the
// full (E)(~(U)x) formula in the containing overflow context.
using System;
enum Narrow : ushort { Seed = 37 }
enum Wide : int { Seed = 37 }
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
    static bool Throws(Narrow value)
    {
        try { return checked(~value) == value; }
        catch (OverflowException) { return true; }
    }
    static int Main()
    {
        Narrow value = Narrow.Seed;
        Check(Throws(value), "checked-overflow");
        Check(unchecked(~value) == (Narrow)65498, "unchecked-complement");
        Wide wide = Wide.Seed;
        Check(checked(~wide) == (Wide)(-38), "int-underlying-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
