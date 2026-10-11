/*
Rules: E15-14-1-iterator-accessor-body
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return N;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Gauge { public int N = 13; public IEnumerable<int> Values { get { yield return N; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = new Gauge().Values.GetEnumerator();
        Check(e.MoveNext(), "property-iterator-has-value");
        Check(e.Current == 13, "property-iterator-value");
        Check(!e.MoveNext(), "property-iterator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
