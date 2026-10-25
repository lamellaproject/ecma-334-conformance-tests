/*
Rules: P08-coalescing-assignment-unconstrained
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: return slot ??= replacement;
Into: return slot = replacement;
*/
using System;

class Program
{
    static int checks, failures;
    static T Ensure<T>(ref T slot, T replacement) { return slot ??= replacement; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = null;
        string supplied = "pine";
        string result = Ensure<string>(ref text, supplied);
        Check(Object.ReferenceEquals(text, supplied) && Object.ReferenceEquals(result, supplied), "generic-null-reference-stores-fallback");
        result = Ensure<string>(ref text, "oak");
        Check(Object.ReferenceEquals(text, supplied) && Object.ReferenceEquals(result, supplied), "generic-present-reference-retained");
        int number = 0;
        int value = Ensure<int>(ref number, 97);
        Check(value == 0 && number == 0, "generic-value-default-is-present");
        int? optional = null;
        int? optionalResult = Ensure<int?>(ref optional, 99);
        Check(optionalResult == 99 && optional == 99, "generic-nullable-value-stores-fallback");
        optional = 101;
        optionalResult = Ensure<int?>(ref optional, 99);
        Check(optionalResult == 101 && optional == 101, "generic-populated-nullable-value-retained");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
