/*
Rules: P08-coalescing-assignment-underlying-result
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: slot ??= 83
Into: slot ??= (int?)83
*/
using System;

class Program
{
    static int checks, failures;
    static int Kind(int value) { return 1; }
    static int Kind(int? value) { return 2; }
    static int Select(ref int? slot) { return Kind(slot ??= 83); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int? slot = null;
        int kind = Select(ref slot);
        Check(kind == 1, "empty-target-has-underlying-result-type");
        Check(slot == 83, "empty-target-stores-underlying-fallback");
        slot = 89;
        kind = Select(ref slot);
        Check(kind == 1, "populated-target-has-underlying-result-type");
        Check(slot == 89, "populated-target-retains-underlying-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
