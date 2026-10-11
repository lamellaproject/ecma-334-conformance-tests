/*
Rules: E12-8-19-negation-context; E12-8-19-checked-arithmetic-runtime
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = checked(-least);
Into: int result = unchecked(-least);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int least = int.MinValue;
        bool overflow = false;
        try { int result = checked(-least); }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-negation-overflow");
        Check(unchecked(-least) == least, "unchecked-negation-low-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
