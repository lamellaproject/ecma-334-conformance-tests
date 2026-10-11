/*
Rules: E7-10-critical-volatile-reference; E7-10-side-effect-volatile-read; E7-10-side-effect-volatile-write; E7-10-side-effect-nonvolatile-write; E7-10-volatile-side-effect-order
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: payload = 173;
Into: payload = 0;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures, payload, observed;
    static volatile int published;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Publish() { payload = 173; published = 1; }
    static void Read()
    {
        while (published == 0) Thread.Yield();
        observed = payload;
    }
    static void Main()
    {
        Thread reader = new Thread(Read), writer = new Thread(Publish);
        reader.Start(); writer.Start();
        // The reader observes the payload before either Join supplies another synchronization point.
        reader.Join(); writer.Join();
        Check(observed == 173, "prior-nonvolatile-write-visible-after-volatile-publication-read");
        Check(published == 1, "volatile-write-is-observed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
