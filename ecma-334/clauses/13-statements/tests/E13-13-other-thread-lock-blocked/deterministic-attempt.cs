/*
Rules: E13-13-other-thread-lock-blocked
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
    static object gate = new object();
    static ManualResetEvent attempted = new ManualResetEvent(false);
    static bool acquiredWhileHeld, acquiredAfterRelease;
    static void Worker()
    {
        acquiredWhileHeld = Monitor.TryEnter(gate);
        if (acquiredWhileHeld) Monitor.Exit(gate);
        attempted.Set();
        lock ((gate)) { acquiredAfterRelease = true; }
    }
    static void Main()
    {
        Thread worker = new Thread(Worker);
        lock (gate)
        {
            worker.Start();
            attempted.WaitOne();
            Check(!acquiredWhileHeld, "other-thread-cannot-acquire-held-lock");
        }
        worker.Join();
        Check(acquiredAfterRelease, "other-thread-acquires-after-release");
        attempted.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
