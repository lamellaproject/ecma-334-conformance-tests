/*
Rules: E12-8-19-addition-context; E12-8-19-checked-form; E12-8-19-unchecked-form; E12-8-19-checked-evaluation; E12-8-19-unchecked-evaluation; E12-8-19-checked-arithmetic-runtime; E12-8-19-unchecked-truncation
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = checked(peak + step);
Into: int result = unchecked(peak + step);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int peak = int.MaxValue, step = 1;
        bool overflow = false;
        try { int result = checked(peak + step); }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-sum-overflow");
        Check(unchecked(peak + step) == int.MinValue, "unchecked-sum-low-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
