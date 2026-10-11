/*
Rules: E15-14-5-2-yield-return-evaluate; E15-14-5-2-iterator-exception-to-movenext-caller; E15-14-5-2-iterator-exception-finally; E15-14-5-2-iterator-exception-after-state
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield return Produce();
Into: yield return 13;
*/
using System;
using System.Collections.Generic;
class Fault : Exception { }
class Program
{
    static int checks, failures;
    static Fault Failure = new Fault();
    static string Trace = "";
    static int Produce() { Trace += "X"; throw Failure; }
    static IEnumerator<int> Sequence() { try { yield return Produce(); } finally { Trace += "F"; } }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(Trace == "", "throwing-operand-deferred-until-movenext");
        Fault caught = null;
        try { e.MoveNext(); }
        catch (Fault ex) { caught = ex; }
        catch (Exception) { }
        Check(caught == Failure, "yield-expression-exception-propagates-unchanged");
        Check(Trace == "XF", "yield-expression-exception-runs-finally");
        Check(!e.MoveNext() && Trace == "XF", "yield-expression-exception-leaves-after");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
