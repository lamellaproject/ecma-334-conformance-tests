/*
Rules: E13-13-same-thread-reentrant-lock
Authority: ECMA-334 7th ed 13.13
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: lock (gate) {
Into: if (true) {
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
        bool stillHeld = false;
        lock (gate)
        {
            lock (gate) {
                Monitor.Exit(gate);
                stillHeld = Monitor.IsEntered(gate);
                Monitor.Enter(gate);
            }
            Check(Monitor.IsEntered(gate), "inner-release-keeps-outer-lock");
        }
        Check(stillHeld, "reentrant-enter-adds-recursion-level");
        Check(!Monitor.IsEntered(gate), "balanced-reentrant-exits-release");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
