/*
Rules: E17-7-ed1-full-initializer-depth
Authority: ECMA-334 1st ed 19.6
Version: ISO-1
Expected: reject
Version-Witness: tests/E17-7-ed1-full-initializer-depth/local-rank-three.witness.cs.part
Mutate: int[,,] cells = {};
Into: int[,,] cells = { { {} } };
*/
// ECMA-334 1st ed 19.6, p. 281 (PDF p. 295), lines 38-41. A multidimensional array
// initializer must explicitly have one nesting level per dimension, even when an earlier
// level is empty.
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
    static int Main()
    {
        int[,,] cells = {};
        Check(cells.Length == 0, "full-depth-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
