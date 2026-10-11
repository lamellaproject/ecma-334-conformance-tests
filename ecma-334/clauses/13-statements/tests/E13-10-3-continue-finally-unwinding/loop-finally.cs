/*
Rules: E13-10-3-continue-finally-unwinding; E13-10-3-form-continue; E13-10-1-form-continue-jump; E13-10-3-continue-target-transfer
Authority: ECMA-334 7th ed 13.10.3
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
    static void Main()
    {
        int trace = 0;
        for (int step = 0; step < 2; step++)
        {
            try { trace = trace * 10 + 1; continue; }
            finally { trace = trace * 10 + 2; }
        }
        Check(trace == 1212, "continue-unwinds-before-next-iteration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
