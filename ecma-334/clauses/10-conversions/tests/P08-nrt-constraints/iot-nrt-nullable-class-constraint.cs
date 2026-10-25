/*
Rules: P08-nrt-constraints
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: where T : class?
Into: where T : class
*/
#nullable enable
using System;

// Updated nullable specification L87/L260; committee types 8.9.
// class? admits a nullable type argument without wrapping its reference.
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static T Echo<T>(T value) where T : class? { return value; }
    static int Main()
    {
        string? empty = null;
        string full = "coupler";
        Check(Object.ReferenceEquals(Echo<string?>(empty), null), "nullable-class-constraint-null");
        Check(Object.ReferenceEquals(Echo<string>(full), full), "nullable-class-constraint-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
