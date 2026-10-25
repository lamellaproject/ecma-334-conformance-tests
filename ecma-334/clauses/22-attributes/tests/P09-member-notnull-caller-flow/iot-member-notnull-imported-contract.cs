/*
Rules: P09-member-notnull-caller-flow
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: none
Fixture: {"libraries":[{"name":"MemberGate","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"MemberGate"}]}}
Mutate: [MemberNotNull(nameof(Text))]
Into: // Imported member contract omitted.
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
#if LIBRARY
public class MemberGate
{
    public string? Text;
    [MemberNotNull(nameof(Text))]
    public void Ready() { Text = "birch"; }
}
#else
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
        MemberGate item = new MemberGate();
        item.Ready();
        Check(item.Text.Length == 5, "member-notnull-imported-member-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
