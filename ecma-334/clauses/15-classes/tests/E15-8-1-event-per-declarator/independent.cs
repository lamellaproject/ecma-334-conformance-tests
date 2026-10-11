/*
Rules: E15-8-1-event-per-declarator
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public event Action East, West;
Into: public event Action East;
*/
using System;
class Source
{
    public event Action East, West;
    public void NotifyEast() { if (East != null) East(); }
    public void NotifyWest() { if (West != null) West(); }
}
class Program
{
    static int checks, failures, east, west;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        source.East += () => east++;
        source.West += () => west++;
        source.NotifyEast();
        Check(east == 1 && west == 0, "first-event-independent");
        source.NotifyWest();
        Check(east == 1 && west == 1, "second-event-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
