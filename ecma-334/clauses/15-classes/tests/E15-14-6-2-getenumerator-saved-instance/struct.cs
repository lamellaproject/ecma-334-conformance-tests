/*
Rules: E15-14-6-2-getenumerator-saved-instance
Authority: ECMA-334 7th ed 15.14.6.2
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: N += 7;
Into: N = 7;
*/
using System;
using System.Collections.Generic;
struct Gauge
{
    public int N;
    public IEnumerable<int> Sequence() { N += 7; yield return N; N += 11; yield return N; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge receiver = new Gauge { N = 13 };
        IEnumerable<int> values = receiver.Sequence();
        receiver.N = 23;
        IEnumerator<int> first = values.GetEnumerator();
        Check(first.MoveNext() && first.Current == 20, "first-enumerator-uses-saved-struct-this");
        Check(first.MoveNext() && first.Current == 31, "first-enumerator-modifies-its-struct-this");
        Check(!first.MoveNext(), "first-struct-enumerator-end");
        first.Dispose();
        IEnumerator<int> second = values.GetEnumerator();
        Check(second.MoveNext() && second.Current == 20, "second-enumerator-restarts-from-original-struct-this");
        Check(second.MoveNext() && second.Current == 31 && receiver.N == 23, "second-struct-this-and-caller-independent");
        Check(!second.MoveNext(), "second-struct-enumerator-end");
        second.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
