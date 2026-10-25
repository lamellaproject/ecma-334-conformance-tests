/*
Rules: P09-pattern-or
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: value is 1 or 4
Into: value is 1 or 5
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Match(int value) { return value is 1 or 4; }
    static int Main()
    {
        Check(Match(1), "left-alternative");
        Check(Match(4), "right-alternative");
        Check(!Match(2), "neither-alternative");
        Check(!Match(5), "nearby-nonmatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
