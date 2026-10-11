/*
Rules: E15-14-1-iterator-accessor-body
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return n;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Gauge { public IEnumerable<int> this[int n] { get { yield return n; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = new Gauge()[13].GetEnumerator();
        Check(e.MoveNext(), "indexer-iterator-has-value");
        Check(e.Current == 13, "indexer-iterator-value");
        Check(!e.MoveNext(), "indexer-iterator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
