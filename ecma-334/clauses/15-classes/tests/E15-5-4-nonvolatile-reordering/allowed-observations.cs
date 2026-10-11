/*
Rules: E15-5-4-nonvolatile-reordering
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Payload = 283;
Into: Payload = 281;
*/
using System;
using System.Threading;
class Program
{
    static int Payload, Mark, ObservedPayload, ObservedMark;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Publish() { Payload = 283; Mark = 1; }
    static void Observe() { ObservedMark = Mark; ObservedPayload = Payload; }
    static void Main()
    {
        Thread publisher = new Thread(Publish);
        Thread observer = new Thread(Observe);
        publisher.Start();
        observer.Start();
        publisher.Join();
        observer.Join();
        // Accept every pairing of the original and written values, including reordered observations.
        Check(ObservedMark == 0 || ObservedMark == 1, "nonvolatile-mark-allowed-values");
        Check(ObservedPayload == 0 || ObservedPayload == 283, "nonvolatile-payload-allowed-values");
        Check(Payload == 283 && Mark == 1, "nonvolatile-writer-completed-after-join");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
