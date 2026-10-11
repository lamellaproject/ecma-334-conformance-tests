/*
Rules: E15-14-5-4-dispose-exception-propagation; E15-14-5-4-dispose-exception-after; E15-14-5-4-suspended-dispose-finally; E15-14-5-4-suspended-dispose-after
Authority: ECMA-334 7th ed 15.14.5.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: throw Failure;
Into: Trace += "N";
*/
using System;
using System.Collections.Generic;
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static string Trace = "";
    static Fault Failure = new Fault();
    static IEnumerator<int> Sequence()
    {
        try { try { yield return 13; Trace += "R"; } finally { Trace += "i"; throw Failure; } }
        finally { Trace += "o"; }
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(e.MoveNext() && e.Current == 13 && Trace == "", "exception-dispose-starts-suspended");
        Fault caught = null;
        try { e.Dispose(); }
        catch (Fault ex) { caught = ex; }
        catch (Exception) { }
        Check(caught == Failure, "dispose-exception-type-and-identity");
        Check(Trace == "io", "outer-finally-runs-after-inner-finally-throws");
        Check(!e.MoveNext() && Trace == "io", "exception-dispose-leaves-after-state");
        e.Dispose();
        Check(Trace == "io", "exception-cleanup-does-not-repeat");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
