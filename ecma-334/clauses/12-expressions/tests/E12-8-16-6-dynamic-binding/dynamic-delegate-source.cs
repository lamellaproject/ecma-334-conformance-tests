/*
Rules: E12-8-16-6-dynamic-binding; E12-8-16-6-dynamic-runtime-type; E12-8-16-6-value-invocation-list
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: dynamic argument = (Callback)Work;
Into: dynamic argument = 7;
*/
using System;
delegate void Callback();
class Program
{
    static int calls;
    static void Work() { calls++; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = (Callback)Work;
        Callback copy = null;
        bool accepted = false;
        try { copy = new Callback(argument); accepted = true; }
        catch (Exception) { }
        Check(accepted && copy != null, "dynamic-source-runtime-delegate-type");
        Check(copy != null && copy.GetInvocationList().Length == 1, "dynamic-source-single-entry");
        if (copy != null) copy();
        Check(calls == 1, "dynamic-created-delegate-invokes-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
