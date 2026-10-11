/*
Rules: E13-7-form-post-increment; E13-7-form-post-decrement
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value++;
Into: value--;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 4;
        value++;
        Check(value == 5, "post-increment-statement");
        value--;
        Check(value == 4, "post-decrement-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
