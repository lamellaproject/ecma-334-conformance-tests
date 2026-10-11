/*
Rules: E13-11-try-block-entry; E13-11-form-try-catch; E13-11-normal-try-exit-without-finally
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: try { trace = 1; }
Into: try { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static void Main()
    {
        try { trace = 1; }
        catch (Exception) { trace = 9; }
        trace = trace * 10 + 2;
        Check(trace == 12, "normal-try-skips-catch-and-reaches-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
