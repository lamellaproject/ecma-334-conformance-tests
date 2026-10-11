/*
Rules: E15-14-5-1-enumerator-implements-nongeneric; E15-14-5-1-enumerator-implements-generic; E15-14-5-1-enumerator-implements-disposable; E15-14-5-1-enumerator-implementation-choice; E15-14-5-1-enumerator-extra-interfaces
Authority: ECMA-334 7th ed 15.14.5.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return 13;
Into: yield break;
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures, Cleanups;
    static IEnumerator<int> Sequence() { try { yield return 13; } finally { Cleanups++; } }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> typed = Sequence();
        // Test the required protocol without restricting its representation or additional interfaces.
        IEnumerator untyped = typed as IEnumerator;
        IDisposable disposable = typed as IDisposable;
        Check(untyped != null && disposable != null, "generic-iterator-required-interfaces");
        Check(untyped != null && untyped.MoveNext(), "nongeneric-view-moves-generic-iterator");
        Check(untyped != null && typed.Current == 13 && (int)untyped.Current == 13, "both-interface-views-current");
        if (disposable != null) disposable.Dispose();
        Check(Cleanups == 1, "disposable-interface-executes-cleanup");
        Check(!typed.MoveNext(), "disposed-iterator-is-after");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
