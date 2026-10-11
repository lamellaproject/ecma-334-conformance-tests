/*
Rules: E12-8-7-1-static-event-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Set(ref Worker.Fired, handler);
Into: Set(ref copy, handler);
*/
using System;
delegate void Pulse();
class Worker
{
    public static event Pulse Fired;
    static void Set(ref Pulse slot, Pulse handler) { slot = handler; }
    public static Pulse Store(Pulse handler)
    {
        Pulse copy = null;
        Set(ref Worker.Fired, handler);
        return Worker.Fired;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Handler() { }
    static void Main()
    {
        Pulse handler = Handler;
        Check(Worker.Store(handler) == handler, "static-field-like-event-is-variable-inside-declaring-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
