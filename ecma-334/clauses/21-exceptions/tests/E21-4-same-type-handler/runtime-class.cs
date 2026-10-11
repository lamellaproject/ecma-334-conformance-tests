/*
Rules: E21-4-same-type-handler
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw original
Into: throw new Exception()
*/
using System;
class Signal : Exception { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception original = new Signal(); bool matched = false, fallback = false;
        try { throw original; }
        catch (Signal caught) { matched = caught == original; }
        catch (Exception) { fallback = true; }
        Check(matched, "runtime-class-and-exception-identity");
        Check(!fallback, "same-type-handler-precedes-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
