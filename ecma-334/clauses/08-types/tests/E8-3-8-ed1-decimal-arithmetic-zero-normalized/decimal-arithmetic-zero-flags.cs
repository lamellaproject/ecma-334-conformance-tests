/*
Rules: E8-3-8-ed1-decimal-arithmetic-zero-normalized
Authority: ECMA-334 1st ed 11.1.6
Version: ISO-1
Expected: run
Stdout: OK 5
Diagnostic: none
Version-Witness: tests/E8-3-8-ed1-decimal-arithmetic-zero-normalized/decimal-arithmetic-zero-flags-witness.cs.part
Mutate: Check(IsCanonicalZero(unit + negative), "addition");
Into: Check(IsCanonicalZero(unit), "addition");
*/
// ECMA-334 1st ed 11.1.6, p. 94 (PDF p. 108), lines 17-18 expressly normalizes arithmetic
// zero sign/scale. GetBits exposes flags. Original failure does not establish mutation
// sensitivity. Witness explicitly normalizes zero.
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
    static bool IsCanonicalZero(decimal value)
    {
        int flags = decimal.GetBits(value)[3];
        return value == 0m && flags == 0;
    }
    public static int Main()
    {
        decimal unit = 1.20m;
        decimal negative = -1.20m;
        decimal zero = 0m;
        Check(IsCanonicalZero(unit + negative), "addition");
        Check(IsCanonicalZero(unit - unit), "subtraction");
        Check(IsCanonicalZero(negative * zero), "multiplication");
        Check(IsCanonicalZero(zero / negative), "division");
        Check(IsCanonicalZero(negative % unit), "remainder");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
