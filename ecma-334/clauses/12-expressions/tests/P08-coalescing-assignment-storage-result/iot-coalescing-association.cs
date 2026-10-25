/*
Rules: P08-coalescing-assignment-storage-result; E12-21-1-right-associative
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: first ??= second ??= Build()
Into: (first ??= second) ?? Build()
*/
using System;

class Program
{
    static int checks, failures, builds;
    static readonly object replacement = new object();
    static object Build() { builds++; return replacement; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object first = null, second = null;
        object result = (first ??= second ??= Build());
        Check(Object.ReferenceEquals(first, replacement) && Object.ReferenceEquals(second, replacement), "right-associated-targets-share-assigned-instance");
        Check(Object.ReferenceEquals(result, replacement), "right-associated-result-identity");
        Check(builds == 1, "right-associated-fallback-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
