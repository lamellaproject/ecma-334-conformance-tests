/*
Rules: P09-unconstrained-parameter-null-input
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Diagnostic: none
Mutate: static bool Missing<T>(T? input)
Into: static bool Missing<T>(T input)
*/
#nullable enable
using System;

class Program
{
    static int checks, failures;
    static bool Missing<T>(T? input) { return input is null; }
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Missing<string>(null), "allow-null-for-nonnullable-reference-argument");
        Check(!Missing<int>(47), "value-input-is-unchanged");
        Check(Missing<int?>(null), "nullable-value-input-is-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
