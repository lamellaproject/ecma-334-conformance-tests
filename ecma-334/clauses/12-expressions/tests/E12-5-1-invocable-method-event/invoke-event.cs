/*
Rules: E12-5-1-invocable-method-event
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Signal();
Into: Signal = null;
*/
using System;
class Box
{
    public event Action Signal;
    public void Raise() { Signal(); }
}
class Program
{
    static int checks, failures, calls;
    static void Handler() { calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); box.Signal += Handler; box.Raise();
        Check(calls == 1, "event-and-method-invocable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
