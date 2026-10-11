/*
Rules: E15-8-1-grammar-event-modifier-form-12
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe event Handler Signal
Into: public event Handler Signal
*/
using System;
unsafe delegate void Handler(int* value);
class Source
{
    public int Trace;
    public unsafe event Handler Signal
    {
        add { int local = 9; value(&local); Trace = local; }
        remove { }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Set(int* value) { *value = 14; }
    static unsafe void Main()
    {
        Source source = new Source();
        source.Signal += Set;
        Check(source.Trace == 14, "unsafe-event-accessor-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
