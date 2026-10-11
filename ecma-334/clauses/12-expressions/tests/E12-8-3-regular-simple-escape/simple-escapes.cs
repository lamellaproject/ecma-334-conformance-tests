/*
Rules: E12-8-3-regular-simple-escape
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string result = $"A\\\n\t\"\'\0\b\f\r\v{3}Z";
Into: string result = $"A\\\t\"\'\0\b\f\r\v{3}Z";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $"A\\\n\t\"\'\0\b\f\r\v{3}Z";
        Check(result == "A\\\n\t\"'\0\b\f\r\v3Z", "regular-simple-escapes-are-decoded");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
