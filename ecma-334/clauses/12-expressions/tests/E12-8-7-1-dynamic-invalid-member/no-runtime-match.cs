/*
Rules: E12-8-7-1-dynamic-invalid-member
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object result = source.Missing;
Into: object result = source.Value;
*/
using System;
class Worker { public int Value = 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic source = new Worker();
        bool rejected = false;
        try { object result = source.Missing; }
        catch (Exception) { rejected = true; }
        Check(rejected, "invalid-dynamic-member-fails-at-runtime-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
