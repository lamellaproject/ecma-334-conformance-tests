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
struct Gauge { public int N; public IEnumerator<int> Sequence() { yield return this.N; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge receiver = new Gauge { N = 13 };
        IEnumerator<int> e = receiver.Sequence();
        receiver.N = 19;
        Check(e.MoveNext(), "saved-struct-receiver-first-value");
        Check(e.Current == 13 && receiver.N == 19, "this-copies-struct-instance-value");
        Check(!e.MoveNext(), "saved-struct-receiver-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
