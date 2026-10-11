/*
Rules: E15-14-6-1-enumerable-copy-instance
Authority: ECMA-334 7th ed 15.14.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return this.N;
Into: yield return 0;
*/
using System;
using System.Collections.Generic;
class Gauge { public int N; public IEnumerable<int> Sequence() { yield return this.N; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge original = new Gauge { N = 13 };
        Gauge receiver = original;
        IEnumerable<int> values = receiver.Sequence();
        receiver = new Gauge { N = 23 };
        original.N = 19;
        IEnumerator<int> e = values.GetEnumerator();
        Check(e.MoveNext(), "enumerable-saved-class-receiver-first-value");
        Check(e.Current == 19 && receiver.N == 23, "enumerable-copies-original-this-reference");
        Check(!e.MoveNext(), "enumerable-saved-class-receiver-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
