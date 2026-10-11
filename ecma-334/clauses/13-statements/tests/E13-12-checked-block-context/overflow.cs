/*
Rules: E13-12-checked-block-context; E13-1-embedded-checked; E13-12-form-checked-statement
Authority: ECMA-334 7th ed 13.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked { sum = largest + one; }
Into: unchecked { sum = largest + one; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int largest = int.MaxValue;
        int one = 1;
        int sum = 0;
        bool rightType = false;
        try { if (true) checked { sum = largest + one; } }
        catch (OverflowException) { rightType = true; }
        catch (Exception) { }
        Check(rightType && sum == 0, "checked-block-throws-overflow-before-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
