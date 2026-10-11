/*
Rules: E8-3-4-struct-event-members
Authority: ECMA-334 7th ed 8.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Handler();
Into: Handler = null;
*/
using System;
delegate void Callback();
struct Sample { public event Callback Handler; public void Raise() { Handler(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static void Touch() { calls++; }
    static void Main()
    {
        Sample sample = new Sample(); sample.Handler += Touch; sample.Raise();
        Check(calls == 1, "struct-event");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
