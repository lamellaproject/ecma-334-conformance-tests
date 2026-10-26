/*
Rules: E6-3-2-ed2-nel-line-terminator
Authority: ECMA-334 2nd ed 9.3.1
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: \xC2\x85
Into: 
*/
using System;
class TokenBoundary
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
        intwidth = 46;
        int height = 7;
        Check(width - height == 39, "nel-token-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
