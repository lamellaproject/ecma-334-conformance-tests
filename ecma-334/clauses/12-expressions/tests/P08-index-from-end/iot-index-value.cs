/*
Rules: P08-index-from-end
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: ^Set(out int distance)
Into: new Index(Set(out int distance), false)
*/
using System;
class Program
{
    static int calls, checks, failures;
    static int Set(out int distance) { calls++; distance = 6; return distance; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Index index = ^Set(out int distance);
        Index end = ^0;
        Index largest = ^int.MaxValue;
        Check(index.Value == 6, "hat-retains-value");
        Check(index.IsFromEnd, "hat-selects-from-end");
        Check(calls == 1 && distance == 6, "operand-once-and-out-assigned");
        Check(end.IsFromEnd && end.Value == 0, "zero-denotes-end");
        Check(largest.IsFromEnd && largest.Value == int.MaxValue, "largest-valid-distance");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
