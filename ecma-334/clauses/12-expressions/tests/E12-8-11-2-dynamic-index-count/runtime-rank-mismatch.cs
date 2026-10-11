/*
Rules: E12-8-11-2-dynamic-index-count
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver[0]
Into: receiver[0, 0]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new int[1, 1];
        bool rejected = false;
        try { object result = receiver[0]; }
        catch (Exception) { rejected = true; }
        Check(rejected, "runtime-array-rank-must-match-index-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
