/*
Rules: E13-9-3-do-first-body; E13-9-3-form-do; E13-9-1-form-do-iteration; E13-9-3-do-condition-evaluation; E13-9-3-do-false-exit
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: do { trace = trace * 10 + 1; } while (Gate());
Into: while (Gate()) { trace = trace * 10 + 1; }
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { trace = trace * 10 + 2; return false; }
    static void Main()
    {
        do { trace = trace * 10 + 1; } while (Gate());
        Check(trace == 12, "body-before-false-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
