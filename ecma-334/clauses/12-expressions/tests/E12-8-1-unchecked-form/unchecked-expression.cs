/*
Rules: E12-8-1-unchecked-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked(value + 1)
Into: checked(value + 1)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = int.MaxValue;
        int result = unchecked(value + 1);
        Check(result == int.MinValue, "unchecked-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
