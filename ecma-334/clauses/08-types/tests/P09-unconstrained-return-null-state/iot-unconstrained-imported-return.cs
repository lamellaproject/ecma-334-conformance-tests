/*
Rules: P09-unconstrained-return-null-state
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: warning
Fixture: {"libraries":[{"name":"ReturnSource","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"ReturnSource"}]}}
Mutate: public static T? Echo<T>(T input)
Into: public static T Echo<T>(T input)
*/
#nullable enable
using System;

#if LIBRARY
public static class ReturnSource
{
    public static T? Echo<T>(T input) { return input; }
    public static T? Empty<T>() { return default; }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = ReturnSource.Echo<string>("alder");
        Check(text == "alder", "imported-maybe-null-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
