/*
Rules: E19-2-ed1-underlying-keyword-tokens
Authority: ECMA-334 1st ed 21.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E19-2-ed1-underlying-keyword-tokens/alias-underlying-name.witness.cs.part
Mutate: enum Mode : StorageWidth
Into: enum Mode : ushort
*/
// ECMA-334 1st ed 21.1, p. 297 (PDF p. 311), lines 15-24. An explicitly specified enum
// base must use a permitted integral keyword token.
using System;
using StorageWidth = System.UInt16;
enum Mode : StorageWidth { Seed = 60001 }
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
        Check((int)Mode.Seed == 60001, "keyword-base-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
