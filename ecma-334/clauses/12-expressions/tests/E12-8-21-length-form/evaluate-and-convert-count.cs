/*
Rules: E12-8-21-length-form; E12-8-21-local-initializer-context; E12-8-21-whole-expression; E12-8-21-span-result; E12-8-21-span-length
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: stackalloc int[Next()]
Into: stackalloc int[3]
*/
using System;
struct Count
{
    public static implicit operator int(Count value) { Program.trace = Program.trace * 10 + 2; return 3; }
}
class Program
{
    static int checks, failures, calls;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Count Next() { calls++; trace = trace * 10 + 1; return new Count(); }
    static void Main()
    {
        Span<int> values = stackalloc int[Next()];
        Check(calls == 1, "count-evaluated-once");
        Check(trace == 12, "count-evaluation-before-int-conversion");
        Check(values.Length == 3, "converted-count-is-length");
        if (values.Length == 3) { values[0] = 7; values[2] = 19; }
        Check(values.Length == 3 && values[0] == 7 && values[2] == 19, "typed-first-and-last-items");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
