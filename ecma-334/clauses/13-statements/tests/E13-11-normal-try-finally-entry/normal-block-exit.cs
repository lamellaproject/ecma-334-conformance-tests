/*
Rules: E13-11-normal-try-finally-entry; E13-11-form-try-finally; E13-11-form-finally; E13-11-finally-normal-end-transfer
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finally { trace = trace * 10 + 2; }
Into: finally { }
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
        finally { trace = trace * 10 + 2; }
        trace = trace * 10 + 3;
        Check(trace == 123, "normal-try-finally-following-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
