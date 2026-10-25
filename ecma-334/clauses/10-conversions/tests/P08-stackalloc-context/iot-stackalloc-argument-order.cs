/*
Rules: P08-stackalloc-context; E12-8-21-initializer-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: stackalloc int[] { Mark(2), Mark(3) }
Into: stackalloc int[] { Mark(3), Mark(2) }
*/
using System;
class Program
{
    static int checks, failures, trace;
    static int Mark(int value) { trace = trace * 10 + value; return value * 11; }
    static int Read(int before, Span<int> data, int after)
    {
        trace = trace * 10 + 5;
        Check(before == 11 && after == 44, "neighbor-arguments");
        Check(data.Length == 2, "nested-allocation-length");
        Check(data[0] == 22 && data[1] == 33, "initializer-elements");
        return data[0] + data[1];
    }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int sum = Read(Mark(1), stackalloc int[] { Mark(2), Mark(3) }, Mark(4));
        Check(sum == 55 && trace == 12345, "arguments-initializers-call-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
