/*
Rules: E15-14-5-1-enumerator-copy-arguments
Authority: ECMA-334 7th ed 15.14.5.1
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
    static IEnumerator<Marker> Sequence(Marker item) { yield return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker original = new Marker { N = 13 };
        Marker argument = original;
        IEnumerator<Marker> e = Sequence(argument);
        argument = new Marker { N = 23 };
        original.N = 19;
        Check(e.MoveNext(), "saved-reference-argument-first-value");
        Check(e.Current == original && e.Current != argument, "reference-value-copied-not-caller-variable");
        Check(e.Current.N == 19, "copied-reference-retains-object-identity");
        Check(!e.MoveNext(), "saved-reference-argument-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
