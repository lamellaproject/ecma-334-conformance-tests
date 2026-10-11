/*
Rules: E13-10-5-return-finally-unwinding; E13-10-5-nonasync-return-to-caller; E13-11-finally-on-try-exit
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: finally { trace = trace * 10 + 2; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static int Produce()
    {
        try
        {
            try { throw new Exception(); }
            catch (Exception) { trace = trace * 10 + 1; return 41; }
            finally { trace = trace * 10 + 2; }
        }
        finally { trace = trace * 10 + 3; }
    }
    static void Main()
    {
        int result = Produce();
        trace = trace * 10 + 4;
        Check(result == 41, "catch-return-result");
        Check(trace == 1234, "inner-finally-outer-finally-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
