/*
Rules: E12-8-16-6-value-evaluation-exception; E12-8-16-6-value-evaluate
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Callback(Read(true))
Into: new Callback(Read(false))
*/
using System;
delegate void Callback();
class Marker : Exception { }
class Program
{
    static int reads, calls;
    static void Work() { calls++; }
    static Callback Read(bool stop) { reads++; if (stop) throw new Marker(); return Work; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Callback old = Work, copy = old;
        bool caught = false;
        try { copy = new Callback(Read(true)); }
        catch (Marker) { caught = true; }
        catch (Exception) { }
        Check(caught && reads == 1, "source-evaluation-exception");
        Check(object.ReferenceEquals(copy, old), "throwing-source-no-new-result");
        Check(calls == 0, "throwing-source-not-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
