/*
Rules: E12-9-5-ed1-enum-complement-context
Authority: ECMA-334 1st ed 14.6.4
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-9-5-ed1-enum-complement-context/constant-byte-complement.witness.cs.part
Mutate: const Narrow Value = ~(Narrow)37;
Into: const Narrow Value = unchecked(~(Narrow)37);
*/
// ECMA-334 1st ed 14.6.4, p. 155 (PDF p. 169), lines 33-36. Enum complement follows the
// full (E)(~(U)x) formula in the containing overflow context.
using System;
enum Narrow : byte { Seed = 37 }
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
    const Narrow Value = ~(Narrow)37;
    static int Main()
    {
        Check(Value == (Narrow)218, "unchecked-constant-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
