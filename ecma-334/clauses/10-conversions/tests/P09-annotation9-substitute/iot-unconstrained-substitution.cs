/*
Rules: P09-annotation9-substitute
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Diagnostic: warning
Mutate: static T? Relay<T>(T input)
Into: static T Relay<T>(T input)
*/
#nullable enable
using System;

class Program
{
    static int checks, failures;
    static T? Relay<T>(T input) { return input; }
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = "harbor";
        string returned = Relay<string>(text);
        int number = Relay<int>(29);
        int? nullableNumber = Relay<int?>(31);
        int? empty = Relay<int?>(null);
        string? emptyText = Relay<string?>(null);
        Check(Object.ReferenceEquals(returned, text), "reference-state-and-identity");
        Check(number == 29, "value-not-wrapped");
        Check(nullableNumber == 31, "nullable-value-not-double-wrapped");
        Check(!empty.HasValue, "nullable-value-null");
        Check(emptyText == null, "annotated-reference-not-double-annotated");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
