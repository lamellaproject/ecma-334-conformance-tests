/*
Rules: E12-8-3-verbatim-end-context
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $@"A{$@"B{3}C"}D"
Into: $@"A{$@"B{8}C"}D"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $@"A{$@"B{3}C"}D";
        Check(result == "AB3CD", "nested-verbatim-string-end-does-not-end-outer-string");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
