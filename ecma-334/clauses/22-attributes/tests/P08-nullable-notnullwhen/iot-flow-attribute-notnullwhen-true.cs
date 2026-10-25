/*
Rules: P08-nullable-notnullwhen
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: if (HasValue(text)) return text.Length;
Into: if (!HasValue(text)) return text.Length;
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static int checks, failures;
    static bool HasValue([NotNullWhen(true)] string? text) { return text != null; }
    static int Size(string? text)
    {
        if (HasValue(text)) return text.Length;
        return -1;
    }
    static string? Take() { return "elm"; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Size(Take()) == 3, "notnull-when-true-branch");
        Check(Size(null) == -1, "null-branch-no-dereference");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
