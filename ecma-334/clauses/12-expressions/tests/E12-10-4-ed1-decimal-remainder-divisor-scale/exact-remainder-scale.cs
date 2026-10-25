/*
Rules: E12-10-4-ed1-decimal-remainder-divisor-scale
Authority: ECMA-334 1st ed 14.7.3
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: tests/E12-10-4-ed1-decimal-remainder-divisor-scale/exact-remainder-scale.witness.cs.part
Mutate: decimal result = 9.0m % 2m;
Into: decimal result = 9.0m / 2m;
*/
// ECMA-334 1st ed 14.7.3, p. 160 (PDF p. 174), lines 6-9. When the exact decimal remainder
// is representable at the divisor scale, its scale equals the divisor scale.
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
        decimal result = 9.0m % 2m;
        Check(result == 1m, "remainder-value");
        Check(((Decimal.GetBits(result)[3] >> 16) & 255) == 0, "divisor-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
