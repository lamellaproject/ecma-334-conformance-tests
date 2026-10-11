/*
Rules: E18-6-2-explicit-event
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: event Notice ISource.Ready
Into: event Notice IOther.Ready
*/
using System;
delegate void Notice();
interface ISource { event Notice Ready; }
class Source : ISource
{
    Notice handler;
    event Notice ISource.Ready { add { handler += value; } remove { handler -= value; } }
    public void Raise() { if (handler != null) handler(); }
}
class Program
{
    static int checks, failures;
    static int calls;
    static void Hit() { calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        ISource view = source;
        view.Ready += Hit;
        source.Raise();
        Check(calls == 1, "explicit-event-add");
        view.Ready -= Hit;
        source.Raise();
        Check(calls == 1, "explicit-event-remove");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
