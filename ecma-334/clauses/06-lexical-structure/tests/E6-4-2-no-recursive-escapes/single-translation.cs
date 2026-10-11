/*
Rules: E6-4-2-no-recursive-escapes
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: "\u005Cn0041"
Into: "\n0041"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string value = "\u005Cn0041";
        Check(value.Length == 6, "no-rescanning");
        Check(value[0] == 92 && value[1] == 110, "backslash-and-letter");
        Check(value == "\\n0041", "remaining-digits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
