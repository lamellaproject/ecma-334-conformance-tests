/*
Rules: E12-8-11-2-dynamic-named-arguments
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver[index: 0]
Into: receiver[0]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new int[] { 3 };
        bool rejected = false;
        int observed = -1;
        try { observed = receiver[index: 0]; }
        // 12.3.1 requires a runtime exception, without specifying its class.
        catch (Exception) { rejected = true; }
        Check(rejected, "runtime-array-access-rejects-named-index");
        Check(observed == -1, "binding-rejection-produces-no-element-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
