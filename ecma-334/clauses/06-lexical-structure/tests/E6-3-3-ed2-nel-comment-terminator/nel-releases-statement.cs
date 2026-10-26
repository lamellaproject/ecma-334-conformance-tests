/*
Rules: E6-3-3-ed2-nel-comment-terminator
Authority: ECMA-334 2nd ed 9.3.2
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: \xC2\x85
Into: \x20
*/
using System;
class CommentBoundary
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
        int score = 14;
        // discarded wordsscore += 9;
        Check(score == 23, "nel-comment-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
