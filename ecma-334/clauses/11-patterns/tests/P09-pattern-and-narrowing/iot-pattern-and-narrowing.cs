/*
Rules: P09-pattern-and-narrowing
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: value is byte and < 12
Into: value is int and < 12
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Match(object value) { return value is byte and < 12; }
    static int Main()
    {
        Check(Match((byte)9), "right-input-narrowed-to-byte");
        Check(!Match((byte)12), "byte-boundary");
        Check(!Match(9), "int-is-not-byte");
        Check(!Match(null), "null-rejected");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
