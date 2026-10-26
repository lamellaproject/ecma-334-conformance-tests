/*
Rules: E6-5-5-ed2-nel-skipped-line-terminator
Authority: ECMA-334 2nd ed 9.5.4
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: \xC2\x85
Into: \x20
*/
using System;
class SkippedBoundary
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
        int observed = 0;
#if false
discarded words#else
        observed = 73;
#endif
        Check(observed == 73, "nel-skipped-line-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
