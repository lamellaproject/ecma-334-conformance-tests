/*
Rules: E13-15-yield-break-finally-unwinding
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw expected;
Into: ;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static Exception expected = new Exception();
    static IEnumerator<int> Items()
    {
        try
        {
            try { trace = 1; yield break; }
            finally { trace = trace * 10 + 2; throw expected; }
        }
        finally { trace = trace * 10 + 3; }
    }
    static void Main()
    {
        IEnumerator<int> cursor = Items();
        Exception observed = null;
        bool completed = false;
        try { bool value = cursor.MoveNext(); completed = true; }
        catch (Exception actual) { observed = actual; }
        Check(!completed && observed == expected, "yield-break-finally-exception-propagates");
        Check(trace == 123, "yield-break-interruption-still-runs-outer-finally");
        cursor.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
