/*
Rules: E13-13-lock-monitor-release
Authority: ECMA-334 7th ed 13.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: lock (gate)
Into: if (true)
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }

    static void Main()
    {
        object gate = new object();
        Exception expected = new Exception(), observed = null;
        bool held = false;
        try { lock (gate) { held = Monitor.IsEntered(gate); throw expected; } }
        catch (Exception actual) { observed = actual; }
        Check(held && observed == expected, "lock-body-exception-propagates");
        Check(!Monitor.IsEntered(gate), "exceptional-exit-releases-monitor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
