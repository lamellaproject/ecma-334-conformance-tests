/*
Rules: E19-2-ed1-underlying-keyword-tokens
Authority: ECMA-334 1st ed 21.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E19-2-ed1-underlying-keyword-tokens/qualified-underlying-name.witness.cs.part
Mutate: enum Mode : System.Int16
Into: enum Mode : short
*/
// ECMA-334 1st ed 21.1, p. 297 (PDF p. 311), lines 15-24. An explicitly specified enum
// base must use a permitted integral keyword token.
using System;
enum Mode : System.Int16 { Seed = 907 }
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
        Check((int)Mode.Seed == 907, "keyword-base-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
