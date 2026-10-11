/*
Rules: E13-11-normal-catch-finally-entry
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finally { trace = trace * 10 + 3; }
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
        try { trace = 1; throw new Exception(); }
        catch (Exception) { trace = trace * 10 + 2; }
        finally { trace = trace * 10 + 3; }
        trace = trace * 10 + 4;
        Check(trace == 1234, "normal-catch-finally-following-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
