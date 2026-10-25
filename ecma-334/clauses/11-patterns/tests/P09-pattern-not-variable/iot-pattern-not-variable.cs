/*
Rules: P09-pattern-not-variable
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: Read() is not int number
Into: Read() is not long number
*/
using System;
// Proposal patterns3.md L248 and alpha-v13 patterns.md L583 forbid declarations
// beneath not. The registered csc accepts this declaration and assigns its
// variable on the false branch; csc is the authority for this later feature.
class Program
{
    static int checks, failures, calls;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static object Read() { calls++; return 17; }
    static int Main()
    {
        calls = 0;
        if (Read() is not int number) Check(false, "false-branch-assignment");
        else Check(number == 17, "false-branch-assignment");
        Check(calls == 1, "single-negated-input-evaluation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
