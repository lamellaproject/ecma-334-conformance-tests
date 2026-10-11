/*
Rules: E13-12-unchecked-block-context; E13-12-form-unchecked-statement
Authority: ECMA-334 7th ed 13.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked { small = (byte)large; }
Into: checked { small = (byte)large; }
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
        bool completed = true;
        try { checked { unchecked { small = (byte)large; } } }
        catch (Exception) { completed = false; }
        Check(completed && small == 44, "inner-unchecked-conversion-overrides-checked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
