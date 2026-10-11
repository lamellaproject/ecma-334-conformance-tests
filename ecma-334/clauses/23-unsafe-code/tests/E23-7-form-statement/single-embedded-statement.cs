/*
Rules: E23-7-form-statement; E23-7-form-declarator; E23-7-scope-embedded-statement
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: fixed (int* pointer = items)
Into: fixed (int* pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] items = { 41 }, other = { 9 };
        fixed (int* pointer = items) Check(*pointer == 41, "fixed-single-embedded-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
