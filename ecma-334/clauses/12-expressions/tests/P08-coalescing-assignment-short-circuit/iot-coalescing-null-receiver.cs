/*
Rules: P08-coalescing-assignment-short-circuit
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: GetNull().Value ??= Next()
Into: GetNull().Value = Next()
*/
using System;

class Cell { public object Value { get; set; } }
class Program
{
    static int checks, failures, receivers, fallbacks;
    static Cell GetNull() { receivers++; return null; }
    static object Next() { fallbacks++; return new object(); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int exceptions = 0;
        try { object ignored = (GetNull().Value ??= Next()); }
        catch (NullReferenceException) { exceptions++; }
        Check(exceptions == 1, "null-receiver-throws-null-reference");
        Check(receivers == 1, "throwing-target-receiver-evaluated-once");
        Check(fallbacks == 0, "target-read-throws-before-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
