/*
Rules: E8-3-8-ed1-fixed-decimal-fraction-limit
Authority: ECMA-334 1st ed 11.1.6
Version: ISO-1
Expected: run
Stdout: OK 3
Diagnostic: none
Mutate: decimal divisor = 2m;
Into: decimal divisor = 1m;
*/
// ECMA-334 1st ed 11.1.6, p. 94 (PDF p. 108) fixes the fractional ceiling at28 and
// requires nearest/even arithmetic rounding; the 7th edition's 8.3.8 may provide more
// places.
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
        decimal quantum = 0.0000000000000000000000000001m;
        decimal divisor = 2m;
        Check(quantum > 0m, "last-decimal-place-exists");
        Check(quantum / divisor == 0m, "half-quantum-rounds-to-even-zero");
        Check((3m * quantum) / divisor == 2m * quantum, "three-halves-round-to-even");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
