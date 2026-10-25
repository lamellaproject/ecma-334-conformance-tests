/*
Rules: P08-coalescing-assignment-storage-result
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: slot ??= (int?)null
Into: slot ??= 0
*/
using System;

class Program
{
    static int checks, failures;
    static int Kind(int value) { return 1; }
    static int Kind(int? value) { return 2; }
    static int Select(ref int? slot) { return Kind(slot ??= (int?)null); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int? slot = null;
        int kind = Select(ref slot);
        Check(kind == 2, "nullable-fallback-retains-nullable-result-type");
        Check(!slot.HasValue, "null-fallback-stores-null");
        slot = 91;
        kind = Select(ref slot);
        Check(kind == 2, "present-value-still-has-nullable-result-type");
        Check(slot == 91, "present-value-retained-with-null-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
