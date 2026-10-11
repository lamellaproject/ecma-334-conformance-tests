/*
Rules: E8-2-2-class-event-members
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Changed();
Into: Changed = null;
*/
using System;
delegate void Callback();
class Device { public event Callback Changed; public void Raise() { Changed(); } }
class Program
{
    static int calls;
    static void OnChange() { calls++; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device device = new Device(); device.Changed += OnChange; device.Raise();
        Check(calls == 1, "class-event-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
