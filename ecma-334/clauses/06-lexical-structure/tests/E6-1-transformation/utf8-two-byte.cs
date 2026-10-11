/*
Rules: E6-1-transformation; E6-1-utf8
Authority: ECMA-334 7th ed 6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \xC3\xA9
Into: e
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = "é";
        Check(text.Length == 1 && text[0] == '\u00E9', "utf8-two-byte-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
