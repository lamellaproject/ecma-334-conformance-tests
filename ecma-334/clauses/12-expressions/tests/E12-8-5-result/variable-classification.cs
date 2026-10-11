/*
Rules: E12-8-5-result
Authority: ECMA-334 7th ed 12.8.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Touch(ref (value));
Into: Touch(ref (value + 0));
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Touch(ref int value) { value++; }
    static void Main()
    {
        int value = 3;
        Touch(ref (value));
        Check(value == 4, "parentheses-preserve-contained-variable-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
