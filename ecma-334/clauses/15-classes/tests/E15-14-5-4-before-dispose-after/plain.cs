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
    static int Calls;
    static IEnumerator<int> Sequence() { Calls++; yield return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        e.Dispose();
        Check(Calls == 0, "plain-before-dispose-does-not-enter-body");
        Check(!e.MoveNext(), "plain-before-dispose-changes-state-to-after");
        Check(Calls == 0, "plain-disposed-before-enumerator-never-enters-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
