/*
Rules: E15-14-3-generic-enumerable-interfaces
Authority: ECMA-334 7th ed 15.14.3
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: yield return value;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Marker { }
class Program
{
    static int checks, failures;
    static IEnumerable<T> Sequence<T>(T value) { yield return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerable<int> numbers = Sequence(13);
        IEnumerator<int> e = numbers.GetEnumerator();
        Check(e.MoveNext(), "value-type-enumerable-has-value");
        Check(e.Current == 13, "value-type-enumerable-value");
        Check(!e.MoveNext(), "value-type-enumerable-end");
        Marker item = new Marker();
        IEnumerable<Marker> objects = Sequence(item);
        IEnumerator<Marker> f = objects.GetEnumerator();
        Check(f.MoveNext(), "reference-type-enumerable-has-value");
        Check(f.Current == item, "reference-type-enumerable-identity");
        Check(!f.MoveNext(), "reference-type-enumerable-end");
        e.Dispose();
        f.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
