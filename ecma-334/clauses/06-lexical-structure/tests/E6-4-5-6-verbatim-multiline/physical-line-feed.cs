/*
Rules: E6-4-5-6-verbatim-multiline
Authority: ECMA-334 7th ed 6.4.5.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: @"north
Into: @"NORTH
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = @"north
south";
        Check(text.Length == 11, "newline-not-removed");
        Check(text[5] == 10, "physical-lf");
        Check(text[0] == 110 && text[6] == 115, "adjacent-contents");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
