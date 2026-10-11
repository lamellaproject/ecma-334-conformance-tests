/*
Rules: E15-14-4-generic-enumerator-yield-argument
Authority: ECMA-334 7th ed 15.14.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return 17;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerator<long> Sequence() { yield return (byte)13; yield return 17; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<long> e = Sequence();
        Check(e.MoveNext(), "generic-enumerator-first");
        long first = e.Current;
        Check(first == 13L, "generic-enumerator-yield-argument-first");
        Check(e.MoveNext(), "generic-enumerator-second");
        long second = e.Current;
        Check(second == 17L, "generic-enumerator-yield-argument-second");
        Check(!e.MoveNext(), "generic-enumerator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
