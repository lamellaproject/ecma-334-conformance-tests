/*
Rules: E8-3-7-ed1-float-subnormal-required
Authority: ECMA-334 1st ed 11.1.5
Version: ISO-1
Expected: run
Stdout: OK 3
Diagnostic: none
Mutate: float value = 5.605193857299268e-45F;
Into: float value = 0;
*/
// ECMA-334 1st ed 11.1.5, p. 93 (PDF p. 107) includes subnormals as valid nonzero values;
// the 7th edition's 8.3.7 explicitly makes support optional.
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
    public static int Main()
    {
        float value = 5.605193857299268e-45F;
        Check(value > 0 && value < 1.0e-37F, "positive-subnormal");
        Check(-value < 0, "negative-subnormal");
        Check(value / 2 > 0, "smaller-nonzero-subnormal");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
