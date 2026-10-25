/*
Rules: P08-nullable-doesnotreturn-contract
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: [DoesNotReturn] static void Claim()
Into: static void Claim()
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class Program
{
    [DoesNotReturn] static void Claim() { }
    static int Main()
    {
        Claim();
        Console.WriteLine("OK 0");
        return 0;
    }
}
