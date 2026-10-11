/*
Rules: E15-14-5-3-running-current-unspecified
Authority: ECMA-334 7th ed 15.14.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int ignored = Active.Current;
Into: Active.Current = 13;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Observations;
    static IEnumerator<int> Active;
    static IEnumerator<int> Sequence()
    {
        // Running-state Current has no required value or exception; observe only completion.
        try { int ignored = Active.Current; }
        catch (Exception) { }
        Observations++;
        yield return 13;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Active = Sequence();
        try { Active.MoveNext(); }
        catch (Exception) { }
        Check(Observations == 1, "running-current-completes-with-unrestricted-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
