/*
Rules: P12-collection-order; P12-collection-array
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 5
Mutate: [Step(1), Step(2), Step(3)]
Into: [Step(2), Step(1), Step(3)]
*/
using System;
class Program
{
    static int checks, failures, trace, calls;
    static int Step(int mark) { trace = trace * 10 + mark; calls++; return mark * 7; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int[] values = [Step(1), Step(2), Step(3)];
        Check(trace == 123 && calls == 3, "expressions-left-to-right-once");
        Check(values.Length == 3, "array-element-count");
        Check(values[0] == 7, "first-value-position");
        Check(values[1] == 14, "second-value-position");
        Check(values[2] == 21, "third-value-position");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
