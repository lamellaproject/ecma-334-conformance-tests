/*
Rules: E13-10-4-goto-finally-unwinding; E13-10-4-goto-target-transfer; E13-10-4-form-goto-label; E13-10-4-goto-label-target; E13-10-1-form-goto-jump; E13-10-1-jump-finally-unwinding; E13-10-1-jump-block-exit-definition
Authority: ECMA-334 7th ed 13.10.4
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
        int trace = 1;
        try
        {
            try { goto done; }
            finally { trace = trace * 10 + 2; }
        }
        finally { trace = trace * 10 + 3; }
        done: Check(trace == 123, "goto-unwinds-inner-before-outer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
