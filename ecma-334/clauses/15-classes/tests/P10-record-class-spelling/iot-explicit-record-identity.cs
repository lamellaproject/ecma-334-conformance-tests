/*
Rules: P10-record-class-spelling; P09-record-reference; P09-record-equality-fields; P09-record-equality-operators
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: record class Token { public int Value; }
Into: record struct Token { public int Value; }
*/
using System;
record class Token { public int Value; }
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
        Token first = new Token { Value = 31 };
        Token alias = first;
        alias.Value = 47;
        Check(ReferenceEquals(first, alias), "explicit-record-class-reference-identity");
        Check(first.Value == 47, "explicit-record-class-shares-instance-state");
        Check(first == new Token { Value = 47 }, "explicit-record-class-field-equality");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
