/*
Rules: E12-8-1-anonymous-object-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new { Value = 3 }
Into: new { Value = 8 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = new { Value = 3 };
        Check(result.Value == 3, "anonymous-object-creation-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
