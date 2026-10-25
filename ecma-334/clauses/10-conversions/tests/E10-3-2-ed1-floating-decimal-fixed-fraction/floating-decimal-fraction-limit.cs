/*
Rules: E10-3-2-ed1-floating-decimal-fixed-fraction
Authority: ECMA-334 1st ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: double source = 2.75e-28;
Into: double source = 4.25e-28;
*/
// ECMA-334 1st ed 13.2.1, p. 117 (PDF p. 131), lines 10-12 and11.1.6 fix fractional scale;
// samples stay away from halfway boundaries.
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
        double source = 2.75e-28;
        decimal quantum = 0.0000000000000000000000000001m;
        Check((decimal)source == 3m * quantum, "positive-nearest-quantum");
        Check((decimal)(-source) == -3m * quantum, "negative-nearest-quantum");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
