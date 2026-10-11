/*
Rules: E13-7-form-assignment
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value += 5;
Into: value -= 5;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value;
        value = 4;
        Check(value == 4, "simple-assignment-statement");
        value += 5;
        Check(value == 9, "compound-assignment-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
