/*
Rules: E6-4-5-6-verbatim-contents; E6-4-5-6-verbatim-quote-value; E6-4-5-6-verbatim-no-backslash-escapes; E6-4-5-6-grammar-string-literal-2; E6-4-5-6-grammar-verbatim-string-literal-1; E6-4-5-6-grammar-verbatim-string-literal-character-1; E6-4-5-6-grammar-verbatim-string-literal-character-2; E6-4-5-6-grammar-single-verbatim-string-literal-character-1; E6-4-5-6-grammar-quote-escape-sequence-1
Authority: ECMA-334 7th ed 6.4.5.6
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: @"gate ""c"""
Into: @"gate ""d"""
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string quoted = @"gate ""c""";
        Check(quoted.Length == 8 && quoted[6] == 99, "verbatim-contents");
        Check(quoted[5] == 34 && quoted[7] == 34, "quote-escape");
        Check(@"\t" == "\\t", "no-simple-escape");
        Check(@"\x2F" == "\\x2F", "no-hex-escape");
        Check(@"\U000003BB" == "\\U000003BB", "no-unicode-escape");
        Check(@"".Length == 0, "empty-verbatim");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
