/*
Rules: P09-member-notnull-caller-flow
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: [MemberNotNull(nameof(Text))]
Into: [MemberNotNull(nameof(Text), nameof(Spare))]
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Box
{
    string? Text, Spare;
    [MemberNotNull(nameof(Text))]
    void Ready() { Text = "oak"; Spare = "ash"; }
    public int Measure()
    {
        Ready();
        return Text.Length + Spare.Length;
    }
}
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
        Check(new Box().Measure() == 6, "member-notnull-unlisted-member-keeps-nullable-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
