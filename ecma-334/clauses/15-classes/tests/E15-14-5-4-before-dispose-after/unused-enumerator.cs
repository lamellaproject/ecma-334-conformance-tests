/*
Rules: E15-14-5-4-before-dispose-after; E15-14-5-4-dispose-cleanup-after
Authority: ECMA-334 7th ed 15.14.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: e.Dispose();
Into: e.MoveNext();
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int BodyCalls, Cleanups;
    static IEnumerator<int> Sequence() { try { BodyCalls++; yield return 13; } finally { Cleanups++; } }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        e.Dispose();
        Check(BodyCalls == 0 && Cleanups == 0, "before-dispose-does-not-enter-body-or-finally");
        Check(!e.MoveNext(), "before-dispose-changes-state-to-after");
        Check(BodyCalls == 0 && Cleanups == 0, "disposed-before-enumerator-never-enters-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
