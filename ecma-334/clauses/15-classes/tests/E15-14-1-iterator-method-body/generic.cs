/*
Rules: E15-14-1-iterator-method-body; E15-14-1-iterator-classification
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return 13;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerable<int> Sequence() { yield return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence().GetEnumerator();
        Check(e.MoveNext(), "method-iterator-has-value");
        Check(e.Current == 13, "method-iterator-value");
        Check(!e.MoveNext(), "method-iterator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
