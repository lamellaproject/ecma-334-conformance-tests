/*
Rules: P08-nullable-notnullwhen-opposite
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: if (!HasValue(text)) return text.Length;
Into: if (HasValue(text)) return text.Length;
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
        // The annotation guarantees only the true branch; this line must warn.
        if (!HasValue(text)) return text.Length;
        return 0;
    }
    static string? Take() { return "elm"; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Size(Take()) == 0, "warning-path-not-executed");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
