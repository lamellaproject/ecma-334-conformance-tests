/*
Rules: P09-member-notnull-return-contract
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: if (assign) Text = "pine";
Into: Text = "pine";
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
        if (assign) Text = "pine";
    }
}
class Program
{
    static int Main()
    {
        new Box().Ready(true);
        Console.WriteLine("OK 0");
        return 0;
    }
}
