/*
Rules: E15-14-5-2-iterator-end-movenext-false; E15-14-5-2-iterator-end-after-state; E15-14-5-2-after-movenext-false
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
    static IEnumerator<int> Sequence() { Trace += "S"; yield return 13; Trace += "E"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(e.MoveNext() && e.Current == 13, "body-end-preceded-by-value");
        Check(Trace == "S", "body-not-yet-ended-at-yield");
        Check(!e.MoveNext() && Trace == "SE", "body-end-returns-false");
        Check(!e.MoveNext() && Trace == "SE", "body-end-transitions-to-after");
        e.Dispose();
        Check(Trace == "SE", "body-end-dispose-does-not-rerun-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
