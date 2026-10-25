/*
Rules: E6-5-6-ed1-message-consumes-nel
Authority: ECMA-334 1st ed 9.5.5
Version: ISO-1
Expected: run
Stdout: OK 1
Source-Diagnostic: [{"case_id":"payload-extent","source":"#warning extent-check","severity":"warning","file":"physical","line":"physical","contains":"#define Enabled"}]
Version-Witness: tests/E6-5-6-ed1-message-consumes-nel/nel-warning-message.witness.cs.part
Mutate: \xC2\x85
Into: \x0A
*/
// ECMA-334 1st ed 9.5.5, p. 67 (PDF p. 81), lines 36-38 consumes the apparent define as
// payload.
#warning extent-check#define Enabled
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
#if Enabled
        int state = 1;
#else
        int state = 0;
#endif
        Check(state == 0, "message-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
