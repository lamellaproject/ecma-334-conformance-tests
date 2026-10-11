/*
Rules: E15-14-5-1-enumerator-invocation-deferred; E15-14-5-1-enumerator-created-returned; E15-14-5-1-enumerator-movenext-executes; E15-14-5-1-enumerator-initial-state; E15-14-5-1-enumerator-state-set
Authority: ECMA-334 7th ed 15.14.5.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: yield return 13;
Into: yield return 17;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerator<int> Sequence() { Trace += "S"; yield return 13; Trace += "E"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> first = Sequence();
        IEnumerator<int> second = Sequence();
        Check(first != null && second != null && first != second, "invocations-create-independent-enumerators");
        Check(Trace == "", "before-state-defers-body");
        Check(first.MoveNext(), "before-movenext-runs-to-suspension");
        Check(first.Current == 13 && Trace == "S", "suspended-state-exposes-value");
        Check(!first.MoveNext() && Trace == "SE", "resumption-runs-to-after-state");
        Check(!first.MoveNext() && Trace == "SE", "after-state-does-not-repeat-body");
        Check(second.MoveNext() && second.Current == 13 && Trace == "SES", "second-enumerator-still-before");
        first.Dispose();
        second.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
