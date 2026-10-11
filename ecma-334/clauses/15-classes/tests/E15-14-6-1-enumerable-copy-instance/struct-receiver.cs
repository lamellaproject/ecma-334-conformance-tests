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
struct Gauge { public int N; public IEnumerable<int> Sequence() { yield return this.N; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge receiver = new Gauge { N = 13 };
        IEnumerable<int> values = receiver.Sequence();
        receiver.N = 19;
        IEnumerator<int> e = values.GetEnumerator();
        Check(e.MoveNext(), "enumerable-saved-struct-receiver-first-value");
        Check(e.Current == 13 && receiver.N == 19, "enumerable-copies-this-struct-value");
        Check(!e.MoveNext(), "enumerable-saved-struct-receiver-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
