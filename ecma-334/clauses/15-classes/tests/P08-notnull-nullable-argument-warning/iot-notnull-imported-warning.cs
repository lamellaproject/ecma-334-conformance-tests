/*
Rules: P08-notnull-nullable-argument-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Fixture: {"libraries":[{"name":"Gate","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"Gate"}]}}
Mutate: Gate.Keep<string?>(null);
Into: Gate.Keep<string>("reed");
*/
#nullable enable
using System;
#if LIBRARY
public static class Gate
{
    public static T Keep<T>(T value) where T : notnull { return value; }
}
#else
class Program
{
    static int Main()
    {
        Gate.Keep<string?>(null);
        Console.WriteLine("OK 0");
        return 0;
    }
}
#endif
