/*
Rules: E7-10-asynchronous-visible-order
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"target_requires":["framework-runtime"]}
Mutate: first = 1;
Into: first = 2;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures, first, second, seenFirst = -1, seenSecond = -1;
    static volatile bool ready;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Work()
    {
        try
        {
            first = 1;
            ready = true;
            while (true) { second = 1; second = 0; }
        }
        catch (ThreadAbortException)
        {
            seenFirst = first; seenSecond = second;
            Thread.ResetAbort();
        }
    }
    static void Main()
    {
        // Thread.Abort is the selected host's asynchronous-interruption API.
        // No relation between the two observed effects or interruption point is required.
        Thread worker = new Thread(Work); worker.Start();
        while (!ready) Thread.Yield();
        worker.Abort(); worker.Join();
        Check(seenFirst == 0 || seenFirst == 1, "asynchronous-observer-accepts-either-whole-first-value");
        Check(seenSecond == 0 || seenSecond == 1, "asynchronous-observer-accepts-either-whole-second-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
