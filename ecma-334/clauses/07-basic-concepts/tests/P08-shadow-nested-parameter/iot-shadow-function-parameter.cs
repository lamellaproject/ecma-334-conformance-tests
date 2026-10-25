/*
Rules: P08-shadow-nested-parameter
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: int Step(int slot)
Into: int Step(int cargo)
*/
using System;
// The earlier nested-name prohibition remains in draft-v8 7.3 L85 and
// alpha-v13 7.2 L161. This test expects the registered csc's C#8 exception.
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Use(int slot)
    {
        int Step(int slot) { return slot + 1; }
        int result = Step(10);
        Check(slot == 6, "outer-parameter-preserved");
        return result;
    }
    static int Main()
    {
        Check(Use(6) == 11, "inner-function-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
