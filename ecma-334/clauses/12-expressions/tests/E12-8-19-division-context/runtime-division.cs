/*
Rules: E12-8-19-division-context
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = checked(least / minusOne);
Into: int result = checked(least / 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int least = int.MinValue, minusOne = -1;
        bool overflow = false;
        // The specific division rule in 12.10.3 permits ArithmeticException or a subclass.
        try { int result = checked(least / minusOne); }
        catch (ArithmeticException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-division-overflow");
        bool allowed = false;
        try { allowed = unchecked(least / minusOne) == least; }
        catch (ArithmeticException) { allowed = true; }
        catch (Exception) { }
        // The unchecked minimum quotient may wrap or throw under 12.10.3.
        Check(allowed, "unchecked-division-allowed-outcome");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
