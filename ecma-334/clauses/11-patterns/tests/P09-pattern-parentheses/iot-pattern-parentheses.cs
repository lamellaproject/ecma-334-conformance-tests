/*
Rules: P09-pattern-parentheses
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: value is (1 or 2) and not 1
Into: value is 1 or (2 and not 1)
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
    static bool Match(int value) { return value is (1 or 2) and not 1; }
    static int Main()
    {
        Check(!Match(1), "grouped-left-excluded");
        Check(Match(2), "grouped-right");
        Check(!Match(3), "outside-group");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
