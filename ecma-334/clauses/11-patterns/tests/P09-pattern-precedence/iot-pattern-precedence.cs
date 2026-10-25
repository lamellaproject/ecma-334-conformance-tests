/*
Rules: P09-pattern-precedence
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: value is >= 9 or >= 3 and <= 5
Into: value is (>= 9 or >= 3) and <= 5
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
    static bool Match(int value) { return value is >= 9 or >= 3 and <= 5; }
    static int Main()
    {
        Check(Match(10), "independent-left-alternative");
        Check(Match(4), "right-conjunction");
        Check(!Match(1), "right-lower-bound");
        Check(!Match(6), "right-upper-bound");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
