/*
Rules: E15-14-2-generic-enumerator-interfaces
Authority: ECMA-334 7th ed 15.14.2
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
    static IEnumerator<T> Sequence<T>(T value) { yield return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> numbers = Sequence(13);
        Check(numbers.MoveNext(), "value-type-enumerator-has-value");
        Check(numbers.Current == 13, "value-type-enumerator-value");
        Check(!numbers.MoveNext(), "value-type-enumerator-end");
        Marker item = new Marker();
        IEnumerator<Marker> objects = Sequence(item);
        Check(objects.MoveNext(), "reference-type-enumerator-has-value");
        Check(objects.Current == item, "reference-type-enumerator-identity");
        Check(!objects.MoveNext(), "reference-type-enumerator-end");
        numbers.Dispose();
        objects.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
