/*
Rules: E13-12-unchecked-block-context; E13-1-embedded-unchecked; E13-12-form-unchecked-statement
Authority: ECMA-334 7th ed 13.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked { sum = largest + one; }
Into: checked { sum = largest + one; }
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
        bool completed = true;
        try { if (true) unchecked { sum = largest + one; } }
        catch (Exception) { completed = false; }
        Check(completed && sum == int.MinValue, "unchecked-block-wraps");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
