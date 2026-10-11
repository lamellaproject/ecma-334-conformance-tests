/*
Rules: E13-10-6-nonasync-propagation-to-caller; E13-10-6-unhandled-function-terminated
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw expected;
Into: return;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static Exception expected = new Exception();
    static void Callee()
    {
        try { trace = trace * 10 + 1; throw expected; }
        finally { trace = trace * 10 + 2; }
    }
    static void Main()
    {
        Exception observed = null;
        try { Callee(); trace = 9; }
        catch (Exception actual) { observed = actual; trace = trace * 10 + 3; }
        Check(observed == expected && trace == 123, "terminated-callee-propagates-at-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
