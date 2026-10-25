/*
Rules: P09-unconstrained-annotation-context
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: none
Mutate: #nullable enable
Into: #nullable disable
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
        Check(Echo<int>(43) == 43, "enabled-unconstrained-annotation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
