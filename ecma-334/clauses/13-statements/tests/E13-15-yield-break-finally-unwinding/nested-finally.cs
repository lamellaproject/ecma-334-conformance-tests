/*
Rules: E13-15-yield-break-finally-unwinding; E13-15-form-yield-break; E13-15-yield-break-end-iteration; E13-15-yield-break-return-to-caller
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield break;
Into: yield return 17;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace;
    static IEnumerator<int> Items()
    {
        try
        {
            try { trace = 1; yield break; }
            finally { trace = trace * 10 + 2; }
        }
        finally { trace = trace * 10 + 3; }
    }
    static void Main()
    {
        IEnumerator<int> cursor = Items();
        bool first = cursor.MoveNext();
        Check(!first && trace == 123, "yield-break-runs-inner-then-outer-finally");
        trace = trace * 10 + 4;
        bool second = cursor.MoveNext();
        Check(!second && trace == 1234, "finished-iterator-does-not-reenter-body");
        cursor.Dispose();
        Check(trace == 1234, "dispose-after-yield-break-does-not-repeat-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
