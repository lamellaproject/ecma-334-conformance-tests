/*
Rules: E15-14-4-nongeneric-enumerable-yield-object
Authority: ECMA-334 7th ed 15.14.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return item;
Into: yield return new Marker();
*/
using System;
using System.Collections;
class Marker { }
class Program
{
    static int checks, failures;
    static IEnumerable Sequence(Marker item) { yield return 13; yield return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        IEnumerator e = Sequence(item).GetEnumerator();
        Check(e.MoveNext(), "object-enumerable-first");
        object boxed = e.Current;
        Check((int)boxed == 13, "enumerable-object-yield-boxes-value");
        Check(e.MoveNext(), "object-enumerable-second");
        object reference = e.Current;
        Check(reference == item, "enumerable-object-yield-reference-identity");
        Check(!e.MoveNext(), "object-enumerable-sequence-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
