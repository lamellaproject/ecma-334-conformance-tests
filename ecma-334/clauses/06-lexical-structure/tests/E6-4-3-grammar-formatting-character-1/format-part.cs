/*
Rules: E6-4-3-grammar-formatting-character-1
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \xE2\x80\x8C
Into: +
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int val‌ue = 67;
        Check(val\u200Cue == 67, "cf-identifier-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
