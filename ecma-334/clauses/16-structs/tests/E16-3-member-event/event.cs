/*
Rules: E16-3-member-event
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: publisher.Notice += Observe;
Into: publisher.Notice -= Observe;
*/
using System;
delegate void Notice();
struct Publisher
{
    public event Notice Notice;
    public void Send() { if (Notice != null) Notice(); }
}
class Program
{
    static int checks, failures;
    static int calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Observe() { calls++; }
    static void Main()
    {
        Publisher publisher = new Publisher(); publisher.Notice += Observe;
        publisher.Send();
        Check(calls == 1, "event-add");
        publisher.Notice -= Observe; publisher.Send();
        Check(calls == 1, "event-remove");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
