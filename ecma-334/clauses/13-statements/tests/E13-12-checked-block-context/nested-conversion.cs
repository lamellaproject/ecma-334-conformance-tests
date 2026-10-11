/*
Rules: E13-12-checked-block-context; E13-12-form-checked-statement
Authority: ECMA-334 7th ed 13.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked { small = (byte)large; }
Into: unchecked { small = (byte)large; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }

    static void Main()
    {
        int large = 300;
        byte small = 7;
        bool overflow = false;
        try { unchecked { checked { small = (byte)large; } } }
        catch (OverflowException) { overflow = true; }
        catch (Exception) { }
        Check(overflow && small == 7, "inner-checked-conversion-overrides-unchecked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
