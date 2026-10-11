/*
Rules: E13-11-catch-exception-finally-entry; E13-11-catch-exception-outward-propagation
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw replacement;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static Exception original = new Exception(), replacement = new Exception();
    static void Main()
    {
        Exception observed = null;
        try
        {
            try { throw original; }
            catch (Exception) { trace = 1; throw replacement; }
            finally { trace = trace * 10 + 2; }
        }
        catch (Exception actual) { observed = actual; trace = trace * 10 + 3; }
        Check(observed == replacement, "catch-exception-goes-to-outer-handler");
        Check(trace == 123, "catch-exception-runs-associated-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
