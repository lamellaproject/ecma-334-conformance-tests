/*
Rules: E15-14-5-1-enumerator-implements-generic; E15-14-5-1-enumerator-implements-nongeneric; E15-14-5-1-enumerator-implements-disposable
Authority: ECMA-334 7th ed 15.14.5.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield return item;
Into: yield return new Marker();
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Marker { }
class Program
{
    static int checks, failures;
    static IEnumerator Sequence(Marker item) { yield return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        IEnumerator untyped = Sequence(item);
        IEnumerator<object> typed = untyped as IEnumerator<object>;
        IDisposable disposable = untyped as IDisposable;
        Check(typed != null && disposable != null, "nongeneric-iterator-required-interfaces");
        Check(untyped.MoveNext(), "nongeneric-source-first-value");
        Check(typed != null && typed.Current == item && untyped.Current == item, "object-yield-type-views-preserve-identity");
        Check(typed != null && !typed.MoveNext(), "generic-view-moves-nongeneric-source-to-end");
        if (disposable != null) disposable.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
