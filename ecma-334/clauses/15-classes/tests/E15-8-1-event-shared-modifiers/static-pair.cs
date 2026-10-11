/*
Rules: E15-8-1-event-shared-modifiers; E15-8-1-grammar-event-modifier-form-6
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static event Action East, West;
Into: public event Action East, West;
*/
using System;
class Source
{
    public static event Action East, West;
    public static void Notify() { if (East != null) East(); if (West != null) West(); }
}
class Program
{
    static int checks, failures, east, west;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source.East += () => east++;
        Source.West += () => west++;
        Source.Notify();
        Check(east == 1, "first-static-event");
        Check(west == 1, "second-static-event");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
