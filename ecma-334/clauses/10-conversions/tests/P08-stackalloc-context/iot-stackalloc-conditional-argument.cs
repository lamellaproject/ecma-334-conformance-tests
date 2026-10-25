/*
Rules: P08-stackalloc-context; E12-18-value-true-arm; E12-18-value-false-arm
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: select ? stackalloc int[] { Mark(1), Mark(2) } : stackalloc int[] { Mark(3), Mark(4), Mark(5) }
Into: !select ? stackalloc int[] { Mark(1), Mark(2) } : stackalloc int[] { Mark(3), Mark(4), Mark(5) }
*/
using System;
class Program
{
    static int checks, failures, trace;
    static int Mark(int value) { trace = trace * 10 + value; return value * 16; }
    static int Read(Span<int> data) { return data.Length * 100 + data[0] + data[data.Length - 1]; }
    static int Select(bool select)
    {
        return Read(select ? stackalloc int[] { Mark(1), Mark(2) } : stackalloc int[] { Mark(3), Mark(4), Mark(5) });
    }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Select(true) == 248, "true-span-value-and-length");
        Check(trace == 12, "only-true-initializers");
        trace = 0;
        Check(Select(false) == 428, "false-span-value-and-length");
        Check(trace == 345, "only-false-initializers");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
