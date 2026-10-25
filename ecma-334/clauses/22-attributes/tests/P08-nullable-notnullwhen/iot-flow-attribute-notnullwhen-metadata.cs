/*
Rules: P08-nullable-notnullwhen
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 1
Diagnostic: none
Fixture: {"libraries":[{"name":"FlowLibrary","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"FlowLibrary"}]}}
Mutate: [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] string? text
Into: string? text
*/
#nullable enable
#if LIBRARY
public static class TextGate
{
    public static bool HasValue([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] string? text)
    { return text != null; }
}
#else
using System;
class Program
{
    static int checks, failures;
    static string? Take() { return "elm"; }
    static int Size(string? text)
    {
        if (TextGate.HasValue(text)) return text.Length;
        return -1;
    }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Size(Take()) == 3, "metadata-postcondition-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
