/*
Rules: E12-8-16-6-dynamic-value-compatibility; E12-8-16-6-dynamic-runtime-type
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic argument = (Narrow)Work;
Into: dynamic argument = (Wide)Other;
*/
using System;
delegate void Narrow(string value);
delegate void Wide(object value);
class Program
{
    static int calls;
    static void Work(string value) { calls++; }
    static void Other(object value) { calls++; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = (Narrow)Work;
        bool caught = false;
        Wide copy = null;
        try { copy = new Wide(argument); }
        catch (Exception) { caught = true; }
        Check(caught && copy == null, "incompatible-runtime-delegate-binding");
        Check(calls == 0, "runtime-binding-does-not-invoke-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
