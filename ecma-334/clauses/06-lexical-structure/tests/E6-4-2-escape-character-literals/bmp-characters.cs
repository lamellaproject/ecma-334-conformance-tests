/*
Rules: E6-4-2-escape-character-literals; E6-4-2-grammar-unicode-escape-sequence-1; E6-4-2-grammar-unicode-escape-sequence-2; E6-4-2-escape-codepoint; E6-4-5-5-grammar-character-4
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: '\u03BB'
Into: '\u03BC'
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check('\u03BB' == 955, "four-digit-codepoint");
        Check('\U00000133' == 307, "eight-digit-codepoint");
        Check('\uD800' == 55296, "surrogate-code-unit");
        Check('\U0000FFFF' == 65535, "bmp-upper-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
