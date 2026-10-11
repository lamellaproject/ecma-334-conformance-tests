/*
Rules: E15-1-finalizer-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: ~Meter()
Into: ~Other()
*/
using System;
class Meter
{
    ~Meter() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // This rule permits a declaration; finalizer scheduling has no oracle here.
        new Meter();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
