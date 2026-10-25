/*
Rules: P09-member-notnull-caller-flow
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: none
Mutate: [MemberNotNull(nameof(Text))]
Into: // Getter member contract omitted.
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Box
{
    string? Text;
    [MemberNotNull(nameof(Text))]
    bool Ready { get { Text = "willow"; return true; } }
    public int Measure()
    {
        bool ready = Ready;
        return ready ? Text.Length : 0;
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
        Check(new Box().Measure() == 6, "member-notnull-getter-establishes-member-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
