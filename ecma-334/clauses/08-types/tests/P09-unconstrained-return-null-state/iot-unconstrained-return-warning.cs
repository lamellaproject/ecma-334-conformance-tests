/*
Rules: P09-unconstrained-return-null-state
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: static T? Echo<T>(T input)
Into: static T Echo<T>(T input)
*/
#nullable enable
using System;

class Program
{
    static int checks, failures;
    static T? Echo<T>(T input) { return input; }
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = Echo<string>("cedar");
        Check(text == "cedar", "maybe-null-return-warning");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
