/*
Rules: P10-record-class-spelling; P09-record-partial-parameter-list; P09-record-reference; P09-record-positional-properties
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: partial record class Part(int Number); partial record Part { public int Extra; }
Into: partial record struct Part(int Number); partial record struct Part { public int Extra; }
*/
using System;
partial record class Part(int Number); partial record Part { public int Extra; }
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
        Part first = new Part(37) { Extra = 5 };
        Part alias = first;
        alias.Extra = 17;
        Check(first.Number == 37, "explicit-record-partial-positional-member");
        Check(first.Extra == 17, "explicit-record-partial-bare-part-state");
        Check(ReferenceEquals(first, alias), "explicit-record-partial-reference-kind");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
