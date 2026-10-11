/*
Rules: E12-8-19-multiplication-context; E12-8-19-checked-arithmetic-runtime
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = checked(left * right);
Into: int result = unchecked(left * right);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left = 65536, right = 32768;
        bool overflow = false;
        try { int result = checked(left * right); }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow, "checked-product-overflow");
        Check(unchecked(left * right) == int.MinValue, "unchecked-product-low-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
