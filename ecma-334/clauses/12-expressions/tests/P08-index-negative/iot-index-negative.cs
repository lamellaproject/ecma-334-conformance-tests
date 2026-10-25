/*
Rules: P08-index-negative
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: ^Read()
Into: ^(-Read())
*/
using System;
class Program
{
    static int calls, checks, failures;
    static int Read() { calls++; return -5; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        bool caught = false;
        try { Index result = ^Read(); }
        catch (ArgumentOutOfRangeException) { caught = true; }
        Check(caught, "negative-distance-exception-type");
        Check(calls == 1, "negative-operand-once-before-throw");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
