/*
Rules: E15-14-5-4-after-dispose-no-effect
Authority: ECMA-334 7th ed 15.14.5.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield return 13;
Into: yield break;
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
        Check(e.MoveNext() && e.Current == 13, "completed-dispose-first-yield");
        Check(!e.MoveNext() && BodyCalls == 1 && Cleanups == 1, "completed-body-enters-after");
        e.Dispose();
        e.Dispose();
        Check(BodyCalls == 1 && Cleanups == 1, "repeated-dispose-after-completion-has-no-effect");
        Check(!e.MoveNext(), "completed-dispose-stays-after");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
