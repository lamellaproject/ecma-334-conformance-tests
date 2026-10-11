/*
Rules: E17-7-element-order; E17-7-initializer-length; E17-7-initializer-list-form
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: { Next(1), Next(2), Next(3) }
Into: { Next(3), Next(2), Next(1) }
*/
using System;
class Program
{
    static int checks, failures, calls, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next(int tag) { calls++; trace = trace * 10 + tag; return tag * 10 + calls; }
    static void Main()
    {
        int[] values = { Next(1), Next(2), Next(3) };
        Check(calls == 3 && trace == 123, "evaluation-once-in-order");
        Check(values.Length == 3, "expression-count-length");
        Check(values[0] == 11, "first-at-zero");
        Check(values[1] == 22, "second-at-one");
        Check(values[2] == 33, "third-at-two");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
