/*
Rules: E10-3-2-ed1-floating-decimal-fixed-underflow
Authority: ECMA-334 1st ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: double source = 1.0e-30;
Into: double source = 1.0e-27;
*/
// ECMA-334 1st ed 13.2.1, p. 117 (PDF p. 131), line 12 with the 1st edition's 11.1.6 fixed
// decimal scale; only numerical zero is required.
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
        double source = 1.0e-30;
        Check((decimal)source == 0m, "positive-underflow");
        Check((decimal)(-source) == 0m, "negative-underflow");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
