/*
Rules: E15-14-5-1-enumerator-copy-instance
Authority: ECMA-334 7th ed 15.14.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return this.N;
Into: yield return 0;
*/
using System;
using System.Collections.Generic;
class Gauge { public int N; public IEnumerator<int> Sequence() { yield return this.N; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge original = new Gauge { N = 13 };
        Gauge receiver = original;
        IEnumerator<int> e = receiver.Sequence();
        receiver = new Gauge { N = 23 };
        original.N = 19;
        Check(e.MoveNext(), "saved-class-receiver-first-value");
        Check(e.Current == 19 && receiver.N == 23, "this-copies-reference-to-original-instance");
        Check(!e.MoveNext(), "saved-class-receiver-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
