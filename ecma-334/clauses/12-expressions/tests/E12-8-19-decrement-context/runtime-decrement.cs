/*
Rules: E12-8-19-decrement-context; E12-8-19-checked-arithmetic-runtime
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int old = checked(value--);
Into: int old = unchecked(value--);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = int.MinValue;
        bool overflow = false;
        try { int old = checked(value--); }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-decrement-overflow");
        Check(value == int.MinValue, "checked-decrement-no-store");
        int previous = unchecked(value--);
        Check(previous == int.MinValue && value == int.MaxValue, "unchecked-decrement-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
