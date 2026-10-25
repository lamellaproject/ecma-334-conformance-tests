/*
Rules: P09-record-reference
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: record Bin
Into: struct Bin
*/
using System;
record Bin { public int Load; }
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Bin first = new Bin();
        Bin alias = first;
        alias.Load = 17;
        Check(first.Load == 17, "shared-state");
        Check(object.ReferenceEquals(first, alias), "reference-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
