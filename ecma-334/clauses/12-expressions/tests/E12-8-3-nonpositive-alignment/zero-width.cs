/*
Rules: E12-8-3-nonpositive-alignment; E12-8-3-width-satisfied
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $"{value,0}"
Into: $"{value,8}"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string value = "token";
        string result = $"{value,0}";
        Check(result == "token", "zero-width-needs-no-padding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
