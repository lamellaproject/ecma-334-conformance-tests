/*
Rules: E6-4-5-4-ed1-zero-decimal-literal-normalized
Authority: ECMA-334 1st ed 9.4.4.3
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Version-Witness: tests/E6-4-5-4-ed1-zero-decimal-literal-normalized/zero-with-scale-witness.cs.part
Mutate: 0.000000m
Into: 0.731000m
*/
// ECMA-334 1st ed 9.4.4.3, p. 59 (PDF p. 73), lines 12-13. A zero decimal literal has sign
// zero and scale zero even when it has an apparent fractional scale.

using System;

class ZeroLiteralProbe
{
    public const decimal Sample = 0.000000m;

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
        int[] bits = decimal.GetBits(Sample);
        Check(bits[3] >= 0, "zero-literal-sign");
        Check(((bits[3] >> 16) & 255) == 0, "zero-literal-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
