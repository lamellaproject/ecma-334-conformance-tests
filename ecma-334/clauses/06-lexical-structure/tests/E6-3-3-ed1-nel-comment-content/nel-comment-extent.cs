/*
Rules: E6-3-3-ed1-nel-comment-content
Authority: ECMA-334 1st ed 9.3.2
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: tests/E6-3-3-ed1-nel-comment-content/nel-comment-extent.witness.cs.part
Mutate: \xC2\x85
Into: \x0A
*/
// ECMA-334 1st ed 9.3.2, p. 53 (PDF p. 67), lines 28-39 keeps NEL inside this comment.
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
        int value = 43;
        // retain the initial value        value = 91;
        Check(value == 43, "comment-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
