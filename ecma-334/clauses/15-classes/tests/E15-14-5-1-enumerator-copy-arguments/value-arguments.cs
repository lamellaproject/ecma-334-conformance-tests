/*
Rules: E15-14-5-1-enumerator-copy-arguments
Authority: ECMA-334 7th ed 15.14.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return n + p.N;
Into: yield return n;
*/
using System;
using System.Collections.Generic;
struct Packet { public int N; }
class Program
{
    static int checks, failures;
    static IEnumerator<int> Sequence(int n, Packet p) { yield return n + p.N; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int n = 6;
        Packet p = new Packet { N = 7 };
        IEnumerator<int> e = Sequence(n, p);
        n = 19;
        p.N = 23;
        Check(e.MoveNext(), "saved-value-arguments-first-value");
        Check(e.Current == 13 && n == 19 && p.N == 23, "arguments-copied-before-deferred-execution");
        Check(!e.MoveNext(), "saved-value-arguments-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
