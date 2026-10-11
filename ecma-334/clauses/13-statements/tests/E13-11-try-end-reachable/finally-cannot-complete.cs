/*
Rules: E13-11-try-end-reachable
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finally { throw expected; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Exception expected = new Exception();
    static int Value() { try { } finally { throw expected; } }
    static void Main()
    {
        Exception observed = null;
        try { int value = Value(); }
        catch (Exception actual) { observed = actual; }
        Check(observed == expected, "nonending-finally-makes-try-end-unreachable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
