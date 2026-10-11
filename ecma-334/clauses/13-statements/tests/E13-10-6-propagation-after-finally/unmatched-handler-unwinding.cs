/*
Rules: E13-10-6-propagation-after-finally; E13-10-6-propagation-finally-execution; E13-11-unmatched-exception-finally-entry; E13-11-unmatched-exception-outward-propagation
Authority: ECMA-334 7th ed 13.10.6
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
    class Specific : Exception { }
    class Other : Exception { }
    static int trace;
    static Specific expected = new Specific();
    static void Main()
    {
        Exception observed = null;
        try
        {
            try { trace = trace * 10 + 1; throw expected; }
            catch (Other) { trace = 9; }
            finally { trace = trace * 10 + 2; }
        }
        catch (Exception actual) { observed = actual; trace = trace * 10 + 3; }
        Check(observed == expected, "exception-survives-completed-finally");
        Check(trace == 123, "unmatched-inner-finally-before-outer-handler");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
