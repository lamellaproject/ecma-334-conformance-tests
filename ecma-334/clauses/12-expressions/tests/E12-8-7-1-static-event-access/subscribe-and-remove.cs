/*
Rules: E12-8-7-1-static-event-access
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Worker.Fired += handler;
Into: Worker.Fired -= handler;
*/
using System;
delegate void Pulse();
class Worker
{
    static Pulse stored;
    public static int adds, removes;
    public static event Pulse Fired
    {
        add { adds++; stored += value; }
        remove { removes++; stored -= value; }
    }
    public static void Raise() { if (stored != null) stored(); }
}
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Handler() { calls++; }
    static void Main()
    {
        Pulse handler = Handler;
        Worker.Fired += handler;
        Worker.Raise();
        Worker.Fired -= handler;
        Worker.Raise();
        Check(calls == 1, "static-event-access-can-subscribe-and-remove-handler");
        Check(Worker.adds == 1 && Worker.removes == 1, "static-event-access-invokes-accessors-without-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
