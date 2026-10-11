/*
Rules: E12-8-1-null-element-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: values?[0]
Into: values[0]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = null;
        int? result = values?[0];
        Check(result == null, "null-conditional-element-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
