/*
Rules: E8-3-8-decimal-to-floating-overflow
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: float converted = (float)value;
Into: float converted = (float)(value / 10000000000000000000000000000m);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal value = decimal.MaxValue; bool allowed = false;
        try { float converted = (float)value; allowed = converted > 7e28f || float.IsPositiveInfinity(converted); }
        catch (OverflowException) { allowed = true; }
        catch (Exception) { }
        Check(allowed, "allowed-decimal-to-floating-outcome");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
