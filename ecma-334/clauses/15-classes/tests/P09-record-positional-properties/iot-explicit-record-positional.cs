/*
Rules: P09-record-positional-properties; P10-record-class-spelling; P09-record-deconstruct; P09-record-equality-fields; P09-record-equality-operators
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 7
Mutate: record class Pair(int First, int Second);
Into: record class Pair(int First, int Second) { public int First { get; init; } = First + 1; }
*/
using System;
record class Pair(int First, int Second);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Pair item = new Pair(31, 47);
        item.Deconstruct(out int first, out int second);
        Pair initialized = new Pair(31, 47) { Second = 59 };
        Check(item.First == 31, "explicit-record-first-positional-property");
        Check(item.Second == 47, "explicit-record-second-positional-property");
        Check(first == 31, "explicit-record-first-deconstruction");
        Check(second == 47, "explicit-record-second-deconstruction");
        Check(item == new Pair(31, 47), "explicit-record-positional-equality");
        Check(item != new Pair(31, 53), "explicit-record-positional-inequality");
        Check(initialized.First == 31 && initialized.Second == 59, "explicit-record-positional-init-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
