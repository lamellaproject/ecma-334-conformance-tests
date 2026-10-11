/*
Rules: E15-3-1-event-category; E15-3-1-grammar-class-member-declaration-form-5
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public event Notice Changed;
Into: public Notice Changed { get; }
*/
using System;
delegate void Notice(int value);
class Source
{
    public event Notice Changed;
    public void Send(int value) { if (Changed != null) Changed(value); }
}
class Program
{
    static int checks, failures, received, calls;
    static void Receive(int value) { received = value; calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source value = new Source();
        value.Changed += Receive;
        value.Send(113);
        Check(received == 113 && calls == 1, "event-generates-notification");
        value.Changed -= Receive;
        value.Send(127);
        Check(received == 113 && calls == 1, "removed-listener-not-notified");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
