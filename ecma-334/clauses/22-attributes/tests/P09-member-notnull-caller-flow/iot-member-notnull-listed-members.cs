/*
Rules: P09-member-notnull-caller-flow
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Diagnostic: none
Mutate: [MemberNotNull(nameof(Text), nameof(Label))]
Into: // Member contract omitted.
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Box
{
    string? Text;
    string? Label { get; set; }
    [MemberNotNull(nameof(Text), nameof(Label))]
    void Ready() { Text = "elm"; Label = "cedar"; }
    public int Measure()
    {
        Ready();
        return Text.Length + Label.Length;
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
        Check(new Box().Measure() == 8, "member-notnull-listed-field-and-property-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
