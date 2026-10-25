/*
Rules: P08-index-lifted
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: ^Next(true)
Into: Next(true)
*/
using System;
class Program
{
    static int calls, checks, failures;
    static int? Next(bool present) { calls++; return present ? (int?)3 : null; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Index? present = ^Next(true);
        Index? absent = ^Next(false);
        Check(present.HasValue && present.Value.Value == 3, "lifted-present-value");
        Check(present.HasValue && present.Value.IsFromEnd, "lifted-present-direction");
        Check(!absent.HasValue, "lifted-null-result");
        Check(calls == 2, "both-operands-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
