/*
Rules: E15-8-1-event-accessibility; E15-8-1-grammar-event-modifier-form-5
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private event Action Signal;
Into: public private event Action Signal;
*/
using System;
class Source
{
    private event Action Signal;
    public event Action Observe { add { Signal += value; } remove { Signal -= value; } }
    public void Notify() { Signal(); }
    public class Client { public static void Attach(Source source, Action handler) { source.Signal += handler; } }
}
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        Source.Client.Attach(source, () => calls++);
        source.Notify();
        Check(calls == 1, "private-event-nested-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
