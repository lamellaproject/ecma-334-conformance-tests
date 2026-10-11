/*
Rules: E15-14-5-2-yield-return-no-finally; E15-14-5-2-yield-return-suspend-body
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return 13;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerator<int> Sequence()
    {
        try { Trace += "O"; try { Trace += "I"; yield return 13; Trace += "R"; } finally { Trace += "i"; } }
        finally { Trace += "o"; }
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(e.MoveNext() && e.Current == 13, "nested-try-first-yield");
        Check(Trace == "OI", "suspension-runs-neither-finally");
        Check(!e.MoveNext(), "nested-try-resumes-to-end");
        Check(Trace == "OIRio", "finally-executes-only-after-resumption");
        e.Dispose();
        Check(Trace == "OIRio", "later-dispose-does-not-repeat-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
