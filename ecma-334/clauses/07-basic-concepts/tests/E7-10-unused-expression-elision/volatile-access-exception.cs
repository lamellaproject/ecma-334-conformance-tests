/*
Rules: E7-10-unused-expression-elision; E7-10-side-effect-volatile-read; E7-10-side-effect-throw
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int unused = missing.Value;
Into: int unused = 0;
*/
using System;
class Cell { public volatile int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool caught = false; Cell missing = null;
        try { int unused = missing.Value; }
        catch (NullReferenceException) { caught = true; }
        catch (Exception) { }
        Check(caught, "discarded-volatile-access-retains-needed-exception-side-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
