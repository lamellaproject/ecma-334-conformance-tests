/*
Rules: E15-14-5-3-nongeneric-current-object-cast
Authority: ECMA-334 7th ed 15.14.5.3
Version: 7.3
Expected: run
Stdout: OK 3
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
    static IEnumerator<Marker> Sequence(Marker item) { yield return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        IEnumerator<Marker> typed = Sequence(item);
        IEnumerator untyped = typed;
        Check(typed.MoveNext(), "reference-current-first-value");
        // 15.14.5.3, p. 463: literal IEnumerable appears to be a typo; this test follows the intent, IEnumerator.
        object viaObject = untyped.Current;
        Check(typed.Current == item && viaObject == (object)typed.Current, "nongeneric-current-object-cast-preserves-identity");
        Check(!typed.MoveNext(), "reference-current-sequence-end");
        typed.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
