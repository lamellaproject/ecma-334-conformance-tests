/*
Rules: E12-23-ed1-constant-cast-targets
Authority: ECMA-334 1st ed 14.15
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-23-ed1-constant-cast-targets/constant-reference-cast.witness.cs.part
Mutate: const object Empty = (object)null;
Into: const object Empty = null;
*/
// ECMA-334 1st ed 14.15, p. 177 (PDF p. 191), lines 1-5. A constant expression cannot
// contain a cast to a reference type other than string, even when its operand is null.
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
    const object Empty = (object)null;
    static int Main()
    {
        Check(Empty == null, "direct-null-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
