/*
Rules: E12-10-3-ed1-decimal-division-smallest-scale
Authority: ECMA-334 1st ed 14.7.2
Version: ISO-1
Expected: run
Stdout: OK 4
Version-Witness: tests/E12-10-3-ed1-decimal-division-smallest-scale/exact-quotient-scale.witness.cs.part
Mutate: decimal first = 8.400m / 2.0m;
Into: decimal first = 8.400m * 2.0m;
*/
// ECMA-334 1st ed 14.7.2, p. 159 (PDF p. 173), lines 6-9. An exact decimal quotient has
// the smallest scale preserving its exact value, rather than a preferred scale derived
// from the operand scales.
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
    static int Scale(decimal value) { return (Decimal.GetBits(value)[3] >> 16) & 255; }
    static int Main()
    {
        decimal first = 8.400m / 2.0m;
        decimal second = 27.00m / 3m;
        Check(first == 4.2m, "fraction-value");
        Check(Scale(first) == 1, "fraction-smallest-scale");
        Check(second == 9m, "integer-value");
        Check(Scale(second) == 0, "integer-smallest-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
