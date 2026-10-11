/*
Rules: E15-8-1-event-explicit-accessors; E15-8-1-grammar-event-declaration-form-2; E15-8-1-grammar-event-accessor-declarations-form-1; E15-8-1-grammar-add-accessor-declaration; E15-8-1-grammar-remove-accessor-declaration
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: handlers += value;
Into: handlers -= value;
*/
using System;
class Source
{
    Action handlers;
    public int Adds, Removes;
    public event Action Signal
    {
        add { Adds++; handlers += value; }
        remove { Removes++; handlers -= value; }
    }
    public void Notify() { if (handlers != null) handlers(); }
}
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        Action handler = () => calls++;
        source.Signal += handler;
        source.Notify();
        Check(calls == 1 && source.Adds == 1, "explicit-add");
        source.Signal -= handler;
        source.Notify();
        Check(calls == 1 && source.Removes == 1, "explicit-remove");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
