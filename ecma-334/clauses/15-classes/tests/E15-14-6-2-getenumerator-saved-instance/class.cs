/*
Rules: E15-14-6-2-getenumerator-saved-instance
Authority: ECMA-334 7th ed 15.14.6.2
Version: 7.3
Expected: run
Stdout: OK 4
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
        IEnumerator<int> first = values.GetEnumerator();
        Check(first.MoveNext() && first.Current == 19, "first-enumerator-uses-saved-class-reference");
        Check(!first.MoveNext(), "first-class-enumerator-end");
        first.Dispose();
        original.N = 29;
        IEnumerator<int> second = values.GetEnumerator();
        Check(second.MoveNext() && second.Current == 29 && receiver.N == 23, "second-enumerator-uses-live-original-object");
        Check(!second.MoveNext(), "second-class-enumerator-end");
        second.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
