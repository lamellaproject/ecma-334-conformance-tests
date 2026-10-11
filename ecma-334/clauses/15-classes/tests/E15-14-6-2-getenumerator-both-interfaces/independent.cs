/*
Rules: E15-14-6-2-getenumerator-both-interfaces; E15-14-6-2-getenumerator-available-object
Authority: ECMA-334 7th ed 15.14.6.2
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: yield return seed;
Into: yield return seed + 7;
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Starts;
    static IEnumerable<int> Sequence(int seed) { Starts++; yield return seed; yield return seed + 1; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerable<int> values = Sequence(13);
        IEnumerator<int> first = values.GetEnumerator();
        IEnumerator second = ((IEnumerable)values).GetEnumerator();
        Check(Starts == 0, "both-getenumerators-defer-body");
        Check(first != null && second != null, "both-getenumerators-return-available-objects");
        Check(first.MoveNext() && first.Current == 13 && Starts == 1, "first-enumerator-first-value");
        Check(first.MoveNext() && first.Current == 14 && Starts == 1, "first-enumerator-second-value");
        Check(second.MoveNext() && (int)second.Current == 13 && Starts == 2, "second-enumerator-starts-independently");
        Check(first.Current == 14, "second-enumerator-does-not-change-first-current");
        Check(!first.MoveNext(), "first-enumerator-end");
        Check(second.MoveNext() && (int)second.Current == 14 && !second.MoveNext(), "second-enumerator-finishes-independently");
        first.Dispose();
        ((IDisposable)second).Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
