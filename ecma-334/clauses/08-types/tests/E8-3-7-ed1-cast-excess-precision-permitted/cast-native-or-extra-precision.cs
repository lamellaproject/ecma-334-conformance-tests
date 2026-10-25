/*
Rules: E8-3-7-ed1-cast-excess-precision-permitted
Authority: ECMA-334 1st ed 11.1.5
Version: ISO-1
Expected: run
Stdout: OK 1
Diagnostic: none
Mutate: double result = (double)(large + one) - large;
Into: double result = (double)(large + (one + one)) - large;
*/
// ECMA-334 1st ed 11.1.5, p. 93 (PDF p. 107), lines 32-38 permits excess precision for all
// floating operations. Both native and extended results are accepted.
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
        double large = 9007199254740992.0;
        double one = 1.0;
        double result = (double)(large + one) - large;
        Check(result == 0.0 || result == 1.0, "native-or-extra-precision");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
