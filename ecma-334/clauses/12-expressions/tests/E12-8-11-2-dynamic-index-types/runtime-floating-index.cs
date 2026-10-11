/*
Rules: E12-8-11-2-dynamic-index-types
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic index = 0.0;
Into: dynamic index = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new int[] { 3 }; dynamic index = 0.0;
        bool rejected = false;
        try { object result = receiver[index]; }
        catch (Exception) { rejected = true; }
        Check(rejected, "runtime-array-index-needs-implicit-integral-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
