/*
Rules: E15-14-5-3-nongeneric-current-object-cast
Authority: ECMA-334 7th ed 15.14.5.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield return new Packet { N = 13 };
Into: yield return new Packet { N = 17 };
*/
using System;
using System.Collections;
using System.Collections.Generic;
struct Packet { public int N; }
class Program
{
    static int checks, failures;
    static IEnumerator<Packet> Sequence() { yield return new Packet { N = 13 }; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<Packet> typed = Sequence();
        IEnumerator untyped = typed;
        Check(typed.MoveNext(), "boxed-current-first-value");
        // 15.14.5.3, p. 463: literal IEnumerable appears to be a typo; this test follows the intent, IEnumerator.
        object boxed = untyped.Current;
        Packet fromGeneric = typed.Current;
        Packet fromObject = (Packet)boxed;
        Check(fromGeneric.N == 13 && fromObject.N == fromGeneric.N, "nongeneric-current-boxes-generic-current");
        fromObject.N = 19;
        Check(typed.Current.N == 13 && ((Packet)boxed).N == 13, "boxed-value-is-independent-of-unboxed-copy");
        Check(!typed.MoveNext(), "boxed-current-sequence-end");
        typed.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
