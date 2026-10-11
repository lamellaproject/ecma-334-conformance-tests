/*
Rules: E15-14-5-3-after-current-unspecified
Authority: ECMA-334 7th ed 15.14.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int ignored = e.Current;
Into: e.Current = 13;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Observations;
    static IEnumerator<int> Sequence() { yield break; }
    static void Observe(IEnumerator<int> e)
    {
        // After-state Current has no required value or exception; observe only completion.
        try { int ignored = e.Current; }
        catch (Exception) { }
        Observations++;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(!e.MoveNext(), "current-probe-enters-after-state");
        Observe(e);
        Check(Observations == 1, "after-current-completes-with-unrestricted-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
