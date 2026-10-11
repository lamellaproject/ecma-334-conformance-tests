/*
Rules: E12-8-7-1-instance-event-access
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: worker.Fired += handler;
Into: worker.Fired -= handler;
*/
using System;
delegate void Pulse();
class Worker
{
    Pulse stored;
    public int adds, removes;
    public event Pulse Fired
    {
        add { adds++; stored += value; }
        remove { removes++; stored -= value; }
    }
    public void Raise() { if (stored != null) stored(); }
}
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Handler() { calls++; }
    static void Main()
    {
        Worker worker = new Worker();
        Pulse handler = Handler;
        worker.Fired += handler;
        worker.Raise();
        worker.Fired -= handler;
        worker.Raise();
        Check(calls == 1, "instance-event-access-can-subscribe-and-remove-handler");
        Check(worker.adds == 1 && worker.removes == 1, "instance-event-access-invokes-accessors-on-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
