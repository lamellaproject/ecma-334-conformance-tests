/*
Rules: P08-nrt-annotations
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Diagnostic: none
Mutate: string? absent = null;
Into: string absent = null;
*/
#nullable enable
using System;

// csharplang nullable-reference-types-specification.md (C# 9), L24;
// draft-v8 types 8.9.1; alpha-v13 types 8.9.1. Annotations preserve identity.
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static object? Echo(object? value) { return value; }
    static int Main()
    {
        string present = "rivet";
        string? annotated = present;
        string? absent = null;
        object?[] elements = new object?[] { annotated, absent };
        Check(Object.ReferenceEquals(present, annotated), "reference-annotation-identity");
        Check(Object.ReferenceEquals(Echo(elements[0]), present), "annotated-array-element-identity");
        Check(Object.ReferenceEquals(elements[1], null), "annotated-array-null-element");
        Check(Object.ReferenceEquals(Echo(absent), null), "nullable-parameter-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
