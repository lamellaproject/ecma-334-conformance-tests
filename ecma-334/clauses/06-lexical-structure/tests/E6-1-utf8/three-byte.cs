/*
Rules: E6-1-utf8; E6-1-transformation
Authority: ECMA-334 7th ed 6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \xE2\x82\xAC
Into: !
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = "€";
        Check(text.Length == 1 && text[0] == '\u20AC', "utf8-three-byte-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
