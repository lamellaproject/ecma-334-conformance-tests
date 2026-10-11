/*
Rules: E15-14-5-1-enumerator-reset-throws
Authority: ECMA-334 7th ed 15.14.5.1
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: e.Reset();
Into: e.MoveNext();
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerator<int> Sequence() { yield return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool ResetThrows(IEnumerator e)
    {
        bool caught = false;
        try { e.Reset(); }
        catch (NotSupportedException) { caught = true; }
        catch (Exception) { }
        return caught;
    }
    static void Main()
    {
        IEnumerator<int> typed = Sequence();
        IEnumerator e = typed;
        Check(ResetThrows(e), "reset-before-throws-not-supported");
        Check(e.MoveNext() && typed.Current == 13, "reset-before-leaves-iterator-before");
        Check(ResetThrows(e), "reset-suspended-throws-not-supported");
        Check(!e.MoveNext(), "reset-suspended-leaves-resumption-intact");
        Check(ResetThrows(e), "reset-after-throws-not-supported");
        Check(!e.MoveNext(), "reset-after-does-not-restart");
        typed.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
