/*
Rules: E12-8-1-pointer-element-form; E12-8-1-stackalloc-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = pointer[0];
Into: int result = pointer[1];
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int* pointer = stackalloc int[2];
        pointer[0] = 3;
        pointer[1] = 8;
        int result = pointer[0];
        Check(result == 3, "pointer-element-is-primary-expression-in-unsafe-code");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
