/*
Rules: P09-member-notnull-return-contract
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: if (!assign) throw new InvalidOperationException();
Into: if (!assign) return;
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Box
{
    public string? Text;
    [MemberNotNull(nameof(Text))]
    public void Ready(bool assign)
    {
        if (!assign) throw new InvalidOperationException();
        Text = "pine";
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
        Box item = new Box();
        bool threw = false;
        try { item.Ready(false); }
        catch (InvalidOperationException) { threw = true; }
        Check(threw, "member-notnull-postcondition-excludes-throwing-exit");
        item.Ready(true);
        Check(item.Text == "pine", "member-notnull-postcondition-normal-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
