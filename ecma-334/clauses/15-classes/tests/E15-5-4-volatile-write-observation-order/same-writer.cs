/*
Rules: E15-5-4-volatile-write-observation-order
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: First = 1; Last = 1;
Into: Last = 1; while (Acknowledged == 0) { } First = 1;
*/
using System;
using System.Threading;
class Program
{
    static volatile int First, Last, Acknowledged;
    static int ObservedFirst, ObservedLast;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Publish() { First = 1; Last = 1; }
    static void Observe()
    {
        int tail;
        do { tail = Last; } while (tail == 0);
        ObservedLast = tail;
        ObservedFirst = First;
        Acknowledged = 1;
    }
    static void Main()
    {
        Thread publisher = new Thread(Publish);
        Thread observer = new Thread(Observe);
        publisher.Start();
        observer.Start();
        publisher.Join();
        observer.Join();
        Check(ObservedLast == 1, "observer-sees-later-volatile-write");
        Check(ObservedFirst == 1, "observer-of-later-write-sees-earlier-write");
        Check(First == 1 && Last == 1, "both-volatile-writes-completed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
