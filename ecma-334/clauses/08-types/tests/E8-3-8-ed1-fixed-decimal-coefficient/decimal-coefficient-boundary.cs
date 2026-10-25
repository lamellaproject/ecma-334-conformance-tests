/*
Rules: E8-3-8-ed1-fixed-decimal-coefficient
Authority: ECMA-334 1st ed 11.1.6
Version: ISO-1
Expected: run
Stdout: OK 3
Diagnostic: none
Mutate: decimal maximum = 79228162514264337593543950335m;
Into: decimal maximum = 79228162514264337593543950333m;
*/
// ECMA-334 1st ed 11.1.6, p. 94 (PDF p. 108), lines 1-6 fixes the coefficient at96 bits.
// The later bound is parameterized.
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
    static void Consume(decimal value) { }
    public static int Main()
    {
        decimal maximum = 79228162514264337593543950335m;
        decimal one = 1m;
        Check(maximum - one == 79228162514264337593543950334m, "last-two-integers");
        bool upper = false;
        try { Consume(maximum + one); }
        catch (OverflowException) { upper = true; }
        Check(upper, "positive-coefficient-overflow");
        bool lower = false;
        try { Consume(-maximum - one); }
        catch (OverflowException) { lower = true; }
        Check(lower, "negative-coefficient-overflow");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
