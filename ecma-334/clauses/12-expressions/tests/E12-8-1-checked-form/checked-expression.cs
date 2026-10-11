/*
Rules: E12-8-1-checked-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked(value + 1)
Into: unchecked(value + 1)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = int.MaxValue;
        bool overflow = false;
        try { int result = checked(value + 1); }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
