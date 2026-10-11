/*
Rules: E15-14-6-2-getenumerator-enumerator-semantics
Authority: ECMA-334 7th ed 15.14.6.2
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: yield return 13;
Into: yield return 19;
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerable<int> Sequence()
    {
        try { Trace += "S"; yield return 13; Trace += "R"; yield return 17; }
        finally { Trace += "F"; }
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerable<int> values = Sequence();
        IEnumerator<int> e = values.GetEnumerator();
        Check(Trace == "", "enumerable-enumerator-initial-before-state");
        Check(e.MoveNext() && Trace == "S", "enumerable-enumerator-enters-and-suspends");
        Check(e.Current == 13 && (int)((IEnumerator)e).Current == 13, "enumerable-enumerator-current-on-both-interfaces");
        IEnumerator resetProbe = ((IEnumerable)values).GetEnumerator();
        bool rejected = false;
        try { resetProbe.Reset(); }
        catch (NotSupportedException) { rejected = true; }
        catch (Exception) { }
        Check(rejected, "enumerable-enumerator-reset-not-supported");
        e.Dispose();
        Check(Trace == "SF", "enumerable-enumerator-dispose-runs-finally-without-resuming-body");
        Check(!e.MoveNext() && Trace == "SF", "enumerable-enumerator-dispose-enters-after-state");
        e.Dispose();
        Check(Trace == "SF", "enumerable-enumerator-after-dispose-has-no-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
