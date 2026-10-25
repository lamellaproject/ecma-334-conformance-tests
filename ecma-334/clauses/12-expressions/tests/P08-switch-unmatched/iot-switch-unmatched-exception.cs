/*
Rules: P08-switch-unmatched
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: 1 => 19
Into: _ => 19
*/
using System;
using System.Runtime.CompilerServices;

// patterns.md L303. draft-v8 permits InvalidOperationException or a subclass;
// alpha-v13 and the registered target name SwitchExpressionException specifically.
class Program
{
    static int checks, failures, inputs;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read() { inputs++; return 7; }
    static int Main()
    {
        bool threw = false;
        int result = 0;
        try { result = Read() switch { 1 => 19 }; }
        catch (SwitchExpressionException) { threw = true; }
        Check(threw, "unmatched-switch-throws-required-exception");
        Check(inputs == 1, "unmatched-input-evaluated-once");
        Check(result == 0, "unmatched-switch-produces-no-arm-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
