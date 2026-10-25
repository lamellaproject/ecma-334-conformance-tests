/*
Rules: P08-stackalloc-context; P08-stackalloc-span; E12-8-21-span-indexer-reference; E12-8-21-span-indexer-bounds
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: (stackalloc short[] { 12, 27, 39 })
Into: (stackalloc short[] { 12, 28, 39 })
*/
using System;
class Program
{
    static int checks, failures;
    static int Kind(Span<short> value) { return 1; }
    static int Kind(short[] value) { return 2; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        var chunk = (stackalloc short[] { 12, 27, 39 });
        Check(Kind(chunk) == 1 && chunk.Length == 3, "parenthesized-var-is-span");
        Check(chunk[0] == 12 && chunk[1] == 27 && chunk[2] == 39, "initial-values");
        ref short cell = ref chunk[1];
        cell = 51;
        Check(chunk[1] == 51, "ref-indexer-updates-allocation");
        bool trapped = false;
        try { short outside = chunk[3]; Check(outside == 0, "unexpected-outside-value"); }
        catch (IndexOutOfRangeException) { trapped = true; }
        Check(trapped, "span-range-check");
        Span<short> direct = stackalloc short[] { 6, 15 };
        Check(Kind(direct) == 1 && direct[1] == 15, "direct-stackalloc-span-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
