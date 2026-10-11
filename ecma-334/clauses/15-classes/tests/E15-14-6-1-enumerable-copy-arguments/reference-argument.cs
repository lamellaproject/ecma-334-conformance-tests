/*
Rules: E15-14-6-1-enumerable-copy-arguments
Authority: ECMA-334 7th ed 15.14.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield return item;
Into: yield return new Marker();
*/
using System;
using System.Collections.Generic;
class Marker { public int N; }
class Program
{
    static int checks, failures;
    static IEnumerable<Marker> Sequence(Marker item) { yield return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker original = new Marker { N = 13 };
        Marker argument = original;
        IEnumerable<Marker> values = Sequence(argument);
        argument = new Marker { N = 23 };
        original.N = 19;
        IEnumerator<Marker> e = values.GetEnumerator();
        Check(e.MoveNext(), "enumerable-saved-reference-first-value");
        Check(e.Current == original && e.Current != argument, "enumerable-copies-reference-value");
        Check(e.Current.N == 19, "enumerable-retains-original-object-not-copy");
        Check(!e.MoveNext(), "enumerable-saved-reference-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
