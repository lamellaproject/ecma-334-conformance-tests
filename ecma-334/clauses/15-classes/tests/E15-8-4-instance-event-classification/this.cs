/*
Rules: E15-8-4-instance-event-classification; E15-8-4-instance-event-association; E15-8-4-instance-event-this
Authority: ECMA-334 7th ed 15.8.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this.Trace += 5;
Into: this.Trace += 6;
*/
using System;
class Source
{
    public int Trace;
    public Source Seen;
    public event Action Signal
    {
        add { this.Trace += 5; this.Seen = this; }
        remove { this.Trace += 9; this.Seen = this; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source first = new Source(), second = new Source();
        Action handler = () => { };
        first.Signal += handler;
        Check(first.Trace == 5 && first.Seen == first && second.Trace == 0, "add-receiver-this");
        second.Signal -= handler;
        Check(second.Trace == 9 && second.Seen == second && first.Trace == 5, "remove-receiver-this");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
