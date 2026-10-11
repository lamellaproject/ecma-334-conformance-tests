/*
Rules: E12-8-19-nonconstant-default
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: peak + step
Into: peak - step
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int peak = int.MaxValue, step = 1;
        bool allowed = false;
        try { allowed = peak + step == int.MinValue; }
        catch (OverflowException) { allowed = true; }
        catch (Exception) { }
        // External compiler switches may change the default to checked.
        Check(allowed, "default-context-allowed-overflow-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
