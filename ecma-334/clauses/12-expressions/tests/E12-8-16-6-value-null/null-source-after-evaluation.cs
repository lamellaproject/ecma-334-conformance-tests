/*
Rules: E12-8-16-6-value-null; E12-8-16-6-value-evaluate
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 4
Version-Witness: version-witnesses/null-source-after-evaluation-41f152a059.cs.part
Mutate: new Callback(Read(null))
Into: new Callback(Read(old))
*/
using System;
delegate void Callback();
class Program
{
    static int reads, calls;
    static void Work() { calls++; }
    static Callback Read(Callback value) { reads++; return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Callback old = Work, copy = old;
        bool caught = false;
        try { copy = new Callback(Read(null)); }
        catch (NullReferenceException) { caught = true; }
        catch (Exception error) { Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        Check(reads == 1, "null-source-evaluated-once");
        Check(caught, "null-source-exception-type");
        Check(object.ReferenceEquals(copy, old), "null-source-no-new-result");
        Check(calls == 0, "null-source-no-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
