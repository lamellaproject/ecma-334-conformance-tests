/*
Rules: E23-5-ed1-null-not-standard-implicit
Authority: ECMA-334 1st ed 25.4
Version: ISO-1
Expected: reject
Version-Witness: tests/E23-5-ed1-null-not-standard-implicit/null-pointer-conversion-chain.witness.cs.part
Mutate: Score score = null;
Into: Score score = (int*)null;
*/
// ECMA-334 1st ed 25.4, p. 327 (PDF p. 341), lines 4-6. Null-to-pointer is an implicit
// pointer conversion but is not added to the standard implicit set.
using System;
unsafe struct Score
{
    public int Value;
    public static implicit operator Score(int* address)
    {
        Score result;
        result.Value = address == null ? 61 : 0;
        return result;
    }
}
unsafe class Entry
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
        Score score = null;
        Check(score.Value == 61, "typed-pointer-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
