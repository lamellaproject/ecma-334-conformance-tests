/*
Rules: E15-14-5-2-iterator-exception-finally; E15-14-5-2-iterator-exception-after-state; E15-14-5-2-iterator-exception-to-movenext-caller
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: throw failure;
Into: yield break;
*/
using System;
using System.Collections.Generic;
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerator<int> Sequence(Fault failure)
    {
        try { Trace += "O"; try { Trace += "I"; yield return 13; Trace += "X"; throw failure; } finally { Trace += "i"; } }
        finally { Trace += "o"; }
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fault failure = new Fault();
        IEnumerator<int> e = Sequence(failure);
        Check(e.MoveNext() && e.Current == 13, "exception-iterator-first-yield");
        Check(Trace == "OI", "no-finally-at-first-yield");
        Fault caught = null;
        try { e.MoveNext(); }
        catch (Fault ex) { caught = ex; }
        catch (Exception) { }
        Check(caught == failure, "exception-type-and-identity-to-movenext-caller");
        Check(Trace == "OIXio", "exception-runs-nested-finally-in-order");
        Check(!e.MoveNext() && Trace == "OIXio", "exception-leaves-after-state");
        e.Dispose();
        Check(Trace == "OIXio", "exception-cleanup-not-repeated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
