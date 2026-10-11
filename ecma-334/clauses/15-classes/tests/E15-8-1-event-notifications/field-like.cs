/*
Rules: E15-8-1-event-notifications; E15-8-1-event-handlers; E15-8-1-grammar-event-declaration-form-1; E15-8-1-event-automatic-accessors; E15-8-1-event-add-operator; E15-8-1-event-add-handler; E15-8-1-event-remove-operator; E15-8-1-event-remove-handler
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: source.Signal -= first;
Into: source.Signal -= second;
*/
using System;
class Source
{
    public event Action Signal;
    public void Notify() { if (Signal != null) Signal(); }
}
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        Action first = () => trace = trace * 10 + 3;
        Action second = () => trace = trace * 10 + 8;
        source.Signal += first;
        source.Signal += second;
        source.Notify();
        Check(trace == 38, "attached-handlers-notified");
        trace = 0;
        source.Signal -= first;
        source.Notify();
        Check(trace == 8, "removed-handler-absent");
        trace = 0;
        source.Signal -= second;
        source.Notify();
        Check(trace == 0, "all-handlers-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
