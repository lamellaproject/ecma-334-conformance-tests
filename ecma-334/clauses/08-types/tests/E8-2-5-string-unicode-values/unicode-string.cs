/*
Rules: E8-2-5-string-unicode-values; E8-2-5-string-literals; E8-2-5-string-alias; E8-2-5-string-direct-base; E8-2-2-predefined-string; E8-2-1-class-form-string
Authority: ECMA-334 7th ed 8.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string text = "A\u03a9\ud834\udd1e";
Into: string text = "A\u03a9x";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = "A\u03a9\ud834\udd1e";
        System.String alias = text; object view = alias;
        Check(text.Length == 4 && text[1] == '\u03a9' && view == text, "unicode-string-and-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
