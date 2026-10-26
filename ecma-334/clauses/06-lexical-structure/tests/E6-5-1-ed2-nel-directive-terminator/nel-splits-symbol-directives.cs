/*
Rules: E6-5-1-ed2-nel-directive-terminator
Authority: ECMA-334 2nd ed 9.5.3
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: \xC2\x85
Into:  //
*/
#define ORCHARD#undef ORCHARD
using System;
class DirectiveBoundary
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
    static int Main()
    {
        int observed = 62;
#if ORCHARD
        observed = 0;
#endif
        Check(observed == 62, "nel-directive-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
