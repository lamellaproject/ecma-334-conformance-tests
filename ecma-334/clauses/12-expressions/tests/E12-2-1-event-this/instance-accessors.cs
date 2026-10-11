/*
Rules: E12-2-1-event-this; E12-2-1-event-type; E12-2-1-event-instance; E12-2-1-event-assignment; E12-6-1-category-events
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Receiver().Signal += Handler;
Into: other.Signal += Handler;
*/
using System;
class Box
{
    public int adds, removes;
    public Action last;
    public event Action Signal
    {
        add { this.adds++; this.last = value; }
        remove { this.removes++; this.last = value; }
    }
}
class Program
{
    static int checks, failures, receivers;
    static Box chosen = new Box(), other = new Box();
    static Box Receiver() { receivers++; return chosen; }
    static void Handler() { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver().Signal += Handler;
        Receiver().Signal -= Handler;
        Check(chosen.adds == 1 && chosen.removes == 1 && other.adds == 0, "event-instance-accessors");
        Check(receivers == 2 && chosen.last == (Action)Handler, "event-type-and-evaluation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
