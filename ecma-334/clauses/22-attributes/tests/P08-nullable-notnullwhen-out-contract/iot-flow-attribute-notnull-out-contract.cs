/*
Rules: P08-nullable-notnullwhen-out-contract
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: [NotNullWhen(true)]
Into: [NotNullWhen(false)]
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Program
{
    // A null output on the promised Boolean outcome violates the out contract.
    static bool Claim([NotNullWhen(true)] out string? text)
    {
        text = null;
        return true;
    }
    static int Main()
    {
        string? text;
        if (!Claim(out text)) return 1;
        Console.WriteLine("OK 0");
        return 0;
    }
}
