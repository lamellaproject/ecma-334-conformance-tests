/*
Rules: E18-4-4-event-form; E18-4-4-class-component-meaning; E18-4-1-member-event
Authority: ECMA-334 7th ed 18.4.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public event Notice Ready { add { handler += value; } remove { handler -= value; } }
Into: public event Notice Ready { add { } remove { handler -= value; } }
*/
using System;
delegate void Notice(int value);
class MarkAttribute : Attribute { }
interface ISource { [Mark] event Notice Ready; }
class Source : ISource
{
    Notice handler;
    public event Notice Ready { add { handler += value; } remove { handler -= value; } }
    public void Raise(int value) { if (handler != null) handler(value); }
}
class Program
{
    static int checks, failures;
    static int calls, saved;
    static void Notice(int value) { calls++; saved = value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        ISource view = source;
        view.Ready += Notice;
        source.Raise(103);
        Check(calls == 1, "interface-event-add");
        Check(saved == 103, "event-parameter");
        view.Ready -= Notice;
        source.Raise(107);
        Check(calls == 1 && saved == 103, "interface-event-remove");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
