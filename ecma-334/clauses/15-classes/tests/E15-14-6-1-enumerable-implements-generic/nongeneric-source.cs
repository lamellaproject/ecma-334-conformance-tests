/*
Rules: E15-14-6-1-enumerable-implements-generic; E15-14-6-1-enumerable-implements-nongeneric
Authority: ECMA-334 7th ed 15.14.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return item;
Into: yield return new Marker();
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Marker { }
class Program
{
    static int checks, failures;
    static IEnumerable Sequence(Marker item) { yield return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        IEnumerable values = Sequence(item);
        IEnumerable<object> typed = values as IEnumerable<object>;
        Check(typed != null, "nongeneric-enumerable-also-implements-object-generic");
        if (typed != null)
        {
            IEnumerator<object> e = typed.GetEnumerator();
            Check(e.MoveNext() && e.Current == item, "object-generic-enumerable-reference-identity");
            Check(!e.MoveNext(), "object-generic-enumerable-end");
            e.Dispose();
        }
        else
        {
            Check(false, "object-generic-enumerable-reference-identity");
            Check(false, "object-generic-enumerable-end");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
