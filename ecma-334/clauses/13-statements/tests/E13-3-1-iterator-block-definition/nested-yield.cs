/*
Rules: E13-3-1-iterator-block-definition; E13-3-1-iterator-yield-return; E13-1-embedded-yield
Authority: ECMA-334 7th ed 13.3.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return 6;
Into: yield return 7;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static IEnumerable<int> Values() { if (true) yield return 6; }
    static void Main()
    {
        IEnumerator<int> e = Values().GetEnumerator();
        Check(e.MoveNext(), "nested-yield-produces-item");
        Check(e.Current == 6, "nested-yield-value");
        Check(!e.MoveNext(), "iterator-endpoint-terminates");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
