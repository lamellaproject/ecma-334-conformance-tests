/*
Rules: E15-14-5-2-yield-return-save-parameters; E15-14-5-2-suspended-movenext-restore-parameters
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: N += 11;
Into: N = 11;
*/
using System;
using System.Collections.Generic;
struct Gauge { public int N; public IEnumerator<int> Sequence() { N += 7; yield return N; N += 11; yield return N; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge receiver = new Gauge { N = 13 };
        IEnumerator<int> e = receiver.Sequence();
        Check(e.MoveNext(), "this-first-yield");
        Check(e.Current == 20 && receiver.N == 13, "iterator-modifies-its-copied-this");
        receiver.N = 23;
        Check(e.MoveNext(), "this-second-yield");
        Check(e.Current == 31 && receiver.N == 23, "modified-this-restored-across-suspension");
        Check(!e.MoveNext(), "this-iterator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
