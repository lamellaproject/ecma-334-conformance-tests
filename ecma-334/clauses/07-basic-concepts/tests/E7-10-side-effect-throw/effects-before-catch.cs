/*
Rules: E7-10-side-effect-throw; E7-10-volatile-side-effect-order
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: throw new InvalidOperationException();
Into: return;
*/
using System;
class Program
{
    static int checks, failures, trace;
    static volatile int marker;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Act() { trace = 1; marker = 2; throw new InvalidOperationException(); }
    static void Main()
    {
        bool caught = false;
        try { Act(); trace = 99; }
        catch (InvalidOperationException) { caught = true; trace = trace * 10 + 3; }
        catch (Exception) { trace = -1; }
        Check(caught, "throw-side-effect-reaches-matching-handler");
        Check(trace == 13, "prior-variable-write-and-throw-preserve-observed-order");
        Check(marker == 2, "volatile-write-before-throw-is-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
