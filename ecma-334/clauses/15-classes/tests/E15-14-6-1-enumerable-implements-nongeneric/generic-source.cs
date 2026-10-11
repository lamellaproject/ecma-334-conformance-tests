/*
Rules: E15-14-6-1-enumerable-implements-nongeneric; E15-14-6-1-enumerable-implements-generic; E15-14-6-1-enumerable-implementation-choice; E15-14-6-1-enumerable-extra-interfaces
Authority: ECMA-334 7th ed 15.14.6.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return 13;
Into: yield break;
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerable<int> Sequence() { yield return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerable<int> typed = Sequence();
        // Required interfaces suffice; no representation or additional-interface restriction is imposed.
        IEnumerable untyped = typed as IEnumerable;
        Check(untyped != null, "generic-enumerable-also-implements-nongeneric");
        IEnumerator<int> e = typed.GetEnumerator();
        Check(e.MoveNext() && e.Current == 13, "generic-enumerable-interface-sequence");
        Check(!e.MoveNext(), "generic-enumerable-interface-end");
        if (untyped != null)
        {
            IEnumerator f = untyped.GetEnumerator();
            Check(f.MoveNext() && (int)f.Current == 13, "nongeneric-enumerable-interface-sequence");
            Check(!f.MoveNext(), "nongeneric-enumerable-interface-end");
        }
        else
        {
            Check(false, "nongeneric-enumerable-interface-sequence");
            Check(false, "nongeneric-enumerable-interface-end");
        }
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
