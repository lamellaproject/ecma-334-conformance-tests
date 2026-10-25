/*
Rules: P09-pattern-and
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: Read() is > 2 and < 8
Into: Read() is > 2 or < 8
*/
using System;
class Program
{
    static int checks, failures, calls, input;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read() { calls++; return input; }
    static bool Match() { return Read() is > 2 and < 8; }
    static int Main()
    {
        input = 5; calls = 0;
        Check(Match(), "both-match");
        Check(calls == 1, "single-input-evaluation");
        input = 2;
        Check(!Match(), "left-fails");
        input = 8;
        Check(!Match(), "right-fails");
        input = 100;
        Check(!Match(), "outside-range");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
