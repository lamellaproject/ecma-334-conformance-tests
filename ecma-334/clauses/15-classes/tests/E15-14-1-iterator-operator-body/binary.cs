/*
Rules: E15-14-1-iterator-operator-body
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return left.N + right.N;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Gauge
{
    public int N;
    public Gauge(int n) { N = n; }
    public static IEnumerable<int> operator +(Gauge left, Gauge right) { yield return left.N + right.N; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = (new Gauge(6) + new Gauge(7)).GetEnumerator();
        Check(e.MoveNext(), "operator-iterator-has-value");
        Check(e.Current == 13, "operator-iterator-value");
        Check(!e.MoveNext(), "operator-iterator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
