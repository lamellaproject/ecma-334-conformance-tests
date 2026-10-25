/*
Rules: E13-6-2-1-ed1-own-initializer-assignment-permitted
Authority: ECMA-334 1st ed 15.5.1
Version: ISO-1
Expected: run
Stdout: OK 1
Diagnostic: none
Mutate: int tally = (tally = 17);
Into: int tally = (tally = 18);
*/
// ECMA-334 1st ed 15.5.1, p. 183 (PDF p. 197), lines 16-25 permits this write after the
// declarator.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        int tally = (tally = 17);
        Check(tally == 17, "own-initializer-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
