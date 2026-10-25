/*
Rules: P09-annotation9-substitute
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: static T? Empty<T>()
Into: static T? Empty<T>() where T : struct
*/
#nullable enable
using System;

class Program
{
    static int checks, failures;
    static T? Empty<T>() { return default; }
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object? boxed = Empty<int>();
        Check(boxed is int, "annotated-value-boxes-zero");
        Check(boxed is int && (int)boxed == 0, "annotated-default-is-value-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
