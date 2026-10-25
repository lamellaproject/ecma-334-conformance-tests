/*
Rules: P09-member-notnull-constructor-flow
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Diagnostic: none
Mutate: [MemberNotNull(nameof(Text), nameof(Label))]
Into: // Constructor helper member contract omitted.
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Box
{
    public static int Calls;
    string Text;
    string Label { get; set; }
    public Box(bool fail) { Ready(fail); }
    [MemberNotNull(nameof(Text), nameof(Label))]
    void Ready(bool fail)
    {
        Calls++;
        if (fail) throw new InvalidOperationException();
        Text = "elm";
        Label = "cedar";
    }
    public int Measure() { return Text.Length + Label.Length; }
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
        Check(new Box(false).Measure() == 8, "member-notnull-constructor-helper-initializes-members");
        bool threw = false;
        try { new Box(true); }
        catch (InvalidOperationException) { threw = true; }
        Check(threw, "member-notnull-constructor-helper-throwing-exit");
        Check(Box.Calls == 2, "member-notnull-constructor-helper-called-once-per-construction");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
