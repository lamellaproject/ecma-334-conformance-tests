/*
Rules: P08-static-local-constants
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: static int Read(int value) { return value + offset; }
Into: static int Read(int value) { return value + different; }
*/
using System;
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
        const int offset = 11;
        const int different = 17;
        static int Read(int value) { return value + offset; }
        Check(Read(23) == 34, "static-local-enclosing-constant");
        Check(Read(different) == 28, "static-local-constant-per-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
