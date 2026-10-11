/*
Rules: E12-8-3-verbatim-open-brace-escape; E12-8-3-verbatim-close-brace-escape; E12-8-3-open-brace-escape; E12-8-3-close-brace-escape
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $@"{{label}}:{3}"
Into: $@"label:{3}"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $@"{{label}}:{3}";
        Check(result == "{label}:3", "verbatim-doubled-braces-are-text");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
