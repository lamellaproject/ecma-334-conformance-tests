/*
Rules: E12-8-7-1-dynamic-method-use
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object result = source.Pick;
Into: object result = source.Pick();
*/
using System;
class Worker { public int Pick() { return 3; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic source = new Worker();
        bool rejected = false;
        try { object result = source.Pick; }
        catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-method-group-cannot-be-used-as-property-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
