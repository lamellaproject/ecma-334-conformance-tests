/*
Rules: E12-8-3-verbatim-form; E12-8-3-verbatim-body; E12-8-3-verbatim-interpolation; E12-8-3-verbatim-start; E12-8-3-verbatim-mid; E12-8-3-verbatim-end; E12-8-3-verbatim-character-element; E12-8-3-verbatim-character-set; E12-8-3-verbatim-quote-escape; E12-8-3-verbatim-mid-context; E12-8-3-verbatim-end-context
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: A\{3}""B
Into: A\{8}""B
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $@"A\{3}""B
C";
        Check(result == "A\\3\"B\nC", "verbatim-text-preserves-backslash-newline-and-escaped-quote");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
