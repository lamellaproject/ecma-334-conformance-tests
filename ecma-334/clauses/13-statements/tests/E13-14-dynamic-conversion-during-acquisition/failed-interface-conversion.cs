/*
Rules: E13-14-dynamic-conversion-during-acquisition
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic value = new Lookalike();
Into: dynamic value = new Resource();
*/
using System;
using Microsoft.CSharp.RuntimeBinder;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Lookalike { public void Dispose() { } }
    class Resource : IDisposable { public void Dispose() { } }
    static void Main()
    {
        dynamic value = new Lookalike();
        bool body = false, correct = false;
        try { using (dynamic resource = value) { body = true; } }
        catch (RuntimeBinderException) { correct = true; }
        catch (Exception) { }
        Check(correct && !body, "dynamic-interface-conversion-before-usage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
