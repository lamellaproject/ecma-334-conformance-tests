/*
Rules: E15-14-4-nongeneric-enumerator-yield-object; E15-14-4-iterator-sequence; E15-14-4-yield-type-definition
Authority: ECMA-334 7th ed 15.14.4
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: yield return item;
Into: yield return new Marker();
*/
using System;
using System.Collections;
class Marker { }
class Program
{
    static int checks, failures;
    static IEnumerator Sequence(Marker item) { yield return 13; yield return item; yield return null; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        IEnumerator e = Sequence(item);
        Check(e.MoveNext(), "object-enumerator-first");
        object boxed = e.Current;
        Check((int)boxed == 13, "object-yield-boxes-value");
        Check(e.MoveNext(), "object-enumerator-second");
        object reference = e.Current;
        Check(reference == item, "object-yield-reference-identity");
        Check(e.MoveNext(), "object-enumerator-third");
        Check(e.Current == null, "object-yield-null");
        Check(!e.MoveNext(), "object-enumerator-sequence-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
