/*
Rules: P08-switch-first-match
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: 9 when Guard(3, true)
Into: 9 when Guard(3, false)
*/
using System;

// patterns.md L303; committee switch expression 12.11/12.12.
// Distinct guard side effects identify the first true guard and unvisited arms.
class Program
{
    static int checks, failures, trace, inputs, values;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read() { inputs++; trace = trace * 10 + 1; return 9; }
    static bool Guard(int marker, bool result) { trace = trace * 10 + marker; return result; }
    static int Yield(int marker, int result) { values++; trace = trace * 10 + marker; return result; }
    static int Main()
    {
        int selected = Read() switch
        {
            9 when Guard(2, false) => Yield(5, 100),
            9 when Guard(3, true) => Yield(6, 37),
            9 when Guard(4, true) => Yield(7, 41),
            _ => Yield(8, 43)
        };
        Check(selected == 37, "first-matching-true-guard");
        Check(trace == 1236, "input-then-needed-guards-then-selected-value");
        Check(inputs == 1, "switch-input-once");
        Check(values == 1, "only-selected-arm-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
