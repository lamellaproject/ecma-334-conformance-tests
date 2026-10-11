/*
Rules: E7-10-critical-lock; E7-10-side-effect-nonvolatile-write
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: payload = 179;
Into: payload = 0;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures, payload, observed;
    static readonly object gate = new object();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Read() { lock (gate) { observed = payload; payload++; } }
    static void Main()
    {
        Thread reader = new Thread(Read);
        lock (gate)
        {
            reader.Start();
            // This write is after Start and before unlock, so Start cannot supply its publication barrier.
            payload = 179;
        }
        reader.Join();
        Check(observed == 179, "reader-lock-acquisition-observes-prior-unlock-effects");
        Check(payload == 180, "locked-read-write-preserves-data-dependence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
