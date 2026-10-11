/*
Rules: E15-14-6-1-enumerable-invocation-deferred; E15-14-6-1-enumerable-created-returned; E15-14-6-1-enumerable-getenumerator-object; E15-14-6-1-enumerable-movenext-executes
Authority: ECMA-334 7th ed 15.14.6.1
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: yield return 13;
Into: yield return 17;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerable<int> Sequence() { Trace += "S"; yield return 13; Trace += "E"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerable<int> values = Sequence();
        Check(values != null && Trace == "", "invocation-returns-enumerable-without-entering-body");
        IEnumerator<int> e = values.GetEnumerator();
        Check(e != null && Trace == "", "getenumerator-returns-object-without-entering-body");
        Check(e.MoveNext(), "enumerable-movenext-enters-body");
        Check(e.Current == 13 && Trace == "S", "enumerable-movenext-runs-to-yield");
        Check(!e.MoveNext() && Trace == "SE", "enumerable-resumption-finishes-body");
        Check(!e.MoveNext() && Trace == "SE", "enumerable-body-not-repeated-after-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
