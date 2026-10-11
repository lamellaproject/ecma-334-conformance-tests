/*
Rules: E15-14-5-4-suspended-dispose-after; E15-14-5-4-dispose-cleanup-after; E15-14-5-4-after-dispose-no-effect
Authority: ECMA-334 7th ed 15.14.5.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: e.Dispose();
Into: e.MoveNext();
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Calls;
    static IEnumerator<int> Sequence() { Calls++; yield return 13; Calls++; yield return 17; }
    static void DisposeAgain(IEnumerator<int> item) { item.Dispose(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(e.MoveNext() && e.Current == 13 && Calls == 1, "plain-dispose-starts-suspended");
        e.Dispose();
        Check(!e.MoveNext(), "plain-suspended-dispose-changes-state-to-after");
        Check(Calls == 1, "plain-disposed-enumerator-does-not-resume-body");
        DisposeAgain(e);
        Check(!e.MoveNext() && Calls == 1, "plain-after-dispose-has-no-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
