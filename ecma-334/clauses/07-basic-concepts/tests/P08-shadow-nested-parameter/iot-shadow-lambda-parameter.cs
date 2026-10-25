/*
Rules: P08-shadow-nested-parameter
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: slot => ++slot
Into: cargo => ++slot
*/
using System;
// Draft-v8 12.21.2 L5368 and alpha-v13 12.22.2 L6055 forbid this
// anonymous-parameter name. The registered csc permits it from C#8.
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int slot = 6;
        Func<int, int> step = slot => ++slot;
        Check(step(10) == 11, "inner-parameter-selected");
        Check(slot == 6, "outer-variable-not-written");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
