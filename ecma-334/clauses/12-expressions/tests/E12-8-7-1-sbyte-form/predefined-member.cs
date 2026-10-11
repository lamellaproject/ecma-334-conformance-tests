/*
Rules: E12-8-7-1-sbyte-form; E12-8-7-1-predefined-member-form
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: sbyte.MaxValue
Into: sbyte.MinValue
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte result = sbyte.MaxValue;
        Check(result == 127, "sbyte-keyword-is-member-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
