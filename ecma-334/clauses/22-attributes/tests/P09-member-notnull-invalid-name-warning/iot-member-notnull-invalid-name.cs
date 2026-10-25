/*
Rules: P09-member-notnull-invalid-name-warning
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: [MemberNotNull("Missing")]
Into: [MemberNotNull(nameof(Text))]
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Box
{
    public string? Text;
    [MemberNotNull("Missing")]
    public void Ready() { Text = "spruce"; }
}
class Program
{
    static int Main()
    {
        new Box().Ready();
        Console.WriteLine("OK 0");
        return 0;
    }
}
