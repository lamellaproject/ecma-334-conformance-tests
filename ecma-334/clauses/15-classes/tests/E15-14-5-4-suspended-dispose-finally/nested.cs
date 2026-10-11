/*
Rules: E15-14-5-4-suspended-dispose-finally; E15-14-5-4-suspended-dispose-after; E15-14-5-4-dispose-cleanup-after; E15-14-5-4-after-dispose-no-effect
Authority: ECMA-334 7th ed 15.14.5.4
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
        Check(e.MoveNext() && e.Current == 13 && Trace == "OI", "dispose-suspended-inside-both-try-blocks");
        e.Dispose();
        Check(Trace == "OIio", "dispose-runs-only-inner-and-outer-finally");
        Check(!e.MoveNext() && Trace == "OIio", "dispose-transitions-suspended-to-after");
        e.Dispose();
        Check(Trace == "OIio", "after-dispose-does-not-repeat-finally");
        Check(!e.MoveNext(), "after-dispose-stays-after");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
