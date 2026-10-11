/*
Rules: E15-14-5-3-suspended-current-last-value; E15-14-5-3-current-affected-by-yield-return
Authority: ECMA-334 7th ed 15.14.5.3
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: yield return 17;
Into: yield return 19;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Evaluations;
    static int Next() { Evaluations++; return 13; }
    static IEnumerator<int> Sequence() { yield return Next(); yield return 17; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(e.MoveNext(), "current-first-yield");
        Check(e.Current == 13 && e.Current == 13, "suspended-current-last-value-repeatable");
        Check(Evaluations == 1, "current-reads-do-not-reevaluate-yield");
        Check(e.MoveNext(), "current-second-yield");
        Check(e.Current == 17 && e.Current == 17, "current-updates-at-next-yield");
        Check(!e.MoveNext(), "current-sequence-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
