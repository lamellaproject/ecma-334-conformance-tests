/*
Rules: E6-5-6-ed2-nel-message-terminator
Authority: ECMA-334 2nd ed 9.5.5
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: \xC2\x85
Into: \x20
*/
#warning boundary#define SWITCHYARD
using System;
class MessageBoundary
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
#if SWITCHYARD
        observed = 74;
#endif
        Check(observed == 74, "nel-message-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
