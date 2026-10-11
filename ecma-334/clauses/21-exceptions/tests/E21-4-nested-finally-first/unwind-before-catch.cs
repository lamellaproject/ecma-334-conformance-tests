/*
Rules: E21-4-nested-finally-first; E21-4-catch-entry
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: finally { trace = trace * 10 + 1; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try
        {
            try
            {
                try { throw new Exception(); }
                finally { trace = trace * 10 + 1; }
            }
            finally { trace = trace * 10 + 2; }
        }
        catch (Exception)
        {
            Check(trace == 12, "nested-finally-order-before-first-catch-statement");
            trace = trace * 10 + 3;
        }
        Check(trace == 123, "catch-entered-after-unwind");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
