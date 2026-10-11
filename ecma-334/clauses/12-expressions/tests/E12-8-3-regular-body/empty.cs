/*
Rules: E12-8-3-regular-body
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string result = $"";
Into: string result = $"x";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $"";
        Check(result == "", "regular-body-can-omit-text-and-interpolations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
