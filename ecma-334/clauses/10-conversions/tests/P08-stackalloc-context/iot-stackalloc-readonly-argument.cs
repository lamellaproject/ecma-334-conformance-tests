/*
Rules: P08-stackalloc-context
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: stackalloc byte[] { 7, 18, 31 }
Into: stackalloc byte[] { 7, 19, 31 }
*/
using System;
class Program
{
    static int checks, failures;
    static int Read(ReadOnlySpan<byte> bytes)
    {
        Check(bytes.Length == 3 && bytes[0] == 7 && bytes[1] == 18 && bytes[2] == 31, "nested-readonly-span-conversion");
        return bytes[1];
    }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int value = Read(stackalloc byte[] { 7, 18, 31 });
        Check(value == 18, "callee-read-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
