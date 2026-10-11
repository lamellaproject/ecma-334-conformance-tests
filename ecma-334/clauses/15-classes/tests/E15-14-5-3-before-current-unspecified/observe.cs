/*
Rules: E15-14-5-3-before-current-unspecified
Authority: ECMA-334 7th ed 15.14.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int ignored = e.Current;
Into: e.Current = 13;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Observations;
    static IEnumerator<int> Sequence() { yield return 13; }
    static void Observe(IEnumerator<int> e)
    {
        // Before-state Current has no required value or exception; observe only completion.
        try { int ignored = e.Current; }
        catch (Exception) { }
        Observations++;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Observe(e);
        Check(Observations == 1, "before-current-completes-with-unrestricted-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
