/*
Rules: P08-recursive-property-nonnull
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: Take() is { }
Into: Take() is null
*/
using System;

class Program
{
    static int checks, failures, calls;
    static object source;
    static object Take() { calls++; return source; }
    static bool Matches() { return Take() is { }; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        source = new object(); calls = 0;
        Check(Matches() && calls == 1, "empty-nonnull-single-input");
        source = null; calls = 0;
        Check(!Matches() && calls == 1, "empty-null-single-input");
        int? present = 47;
        int? absent = null;
        Check(present is { }, "nullable-present");
        Check(!(absent is { }), "nullable-absent");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
