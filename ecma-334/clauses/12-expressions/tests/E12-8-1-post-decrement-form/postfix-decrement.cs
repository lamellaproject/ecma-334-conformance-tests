/*
Rules: E12-8-1-post-decrement-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = value--;
Into: int result = --value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 3;
        int result = value--;
        Check(result == 3, "post-decrement-is-primary-expression");
        Check(value == 2, "post-decrement-writes-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
