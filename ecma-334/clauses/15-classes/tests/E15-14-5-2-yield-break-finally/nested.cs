/*
Rules: E15-14-5-2-yield-break-finally; E15-14-5-2-yield-break-after-state; E15-14-5-2-yield-break-movenext-false; E15-14-5-2-after-movenext-false
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield break;
Into: yield return 17;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerator<int> Sequence(bool stop)
    {
        try { Trace += "O"; try { Trace += "I"; if (stop) yield break; yield return 13; } finally { Trace += "i"; } }
        finally { Trace += "o"; }
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence(true);
        Check(!e.MoveNext(), "yield-break-returns-false");
        Check(Trace == "OIio", "yield-break-executes-inner-then-outer-finally");
        Check(!e.MoveNext() && Trace == "OIio", "yield-break-leaves-after-state");
        e.Dispose();
        Check(Trace == "OIio", "after-yield-break-dispose-has-no-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
