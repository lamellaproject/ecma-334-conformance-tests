/*
Rules: E13-15-yield-iterator-suspension; E13-15-yield-current-assignment; E13-15-yield-return-defers-finally; E13-15-yield-movenext-resumption; E13-15-form-yield-return; E13-15-yield-movenext-true
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return 6;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static IEnumerator<int> Items()
    {
        try { trace = 1; yield return 6; trace = trace * 10 + 2; }
        finally { trace = trace * 10 + 3; }
    }
    static void Main()
    {
        IEnumerator<int> cursor = Items();
        bool first = cursor.MoveNext();
        Check(first, "yield-reports-element");
        Check(cursor.Current == 6, "yield-sets-current");
        Check(trace == 1, "suspension-defers-remainder-and-finally");
        bool second = cursor.MoveNext();
        Check(!second, "resumption-reaches-end");
        Check(trace == 123, "resumption-runs-remainder-then-finally");
        cursor.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
