/*
Rules: E12-8-19-subtraction-context; E12-8-19-checked-arithmetic-runtime
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = checked(least - step);
Into: int result = unchecked(least - step);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int least = int.MinValue, step = 1;
        bool overflow = false;
        try { int result = checked(least - step); }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-difference-overflow");
        Check(unchecked(least - step) == int.MaxValue, "unchecked-difference-low-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
