/*
Rules: E6-4-5-5-grammar-character-literal-1; E6-4-5-5-grammar-character-1; E6-4-5-5-grammar-character-2; E6-4-5-5-grammar-single-character-1; E6-4-5-5-grammar-simple-escape-sequence-1; E6-4-5-5-grammar-simple-escape-sequence-2; E6-4-5-5-grammar-simple-escape-sequence-3; E6-4-5-5-grammar-simple-escape-sequence-4; E6-4-5-5-grammar-simple-escape-sequence-5; E6-4-5-5-grammar-simple-escape-sequence-6; E6-4-5-5-grammar-simple-escape-sequence-7; E6-4-5-5-grammar-simple-escape-sequence-8; E6-4-5-5-grammar-simple-escape-sequence-9; E6-4-5-5-grammar-simple-escape-sequence-10; E6-4-5-5-grammar-simple-escape-sequence-11; E6-4-5-5-simple-escape-single-quote; E6-4-5-5-simple-escape-double-quote; E6-4-5-5-simple-escape-backslash; E6-4-5-5-simple-escape-null; E6-4-5-5-simple-escape-alert; E6-4-5-5-simple-escape-backspace; E6-4-5-5-simple-escape-form-feed; E6-4-5-5-simple-escape-line-feed; E6-4-5-5-simple-escape-carriage-return; E6-4-5-5-simple-escape-horizontal-tab; E6-4-5-5-simple-escape-vertical-tab; E6-4-5-5-character-type; E6-4-5-1-grammar-literal-4
Authority: ECMA-334 7th ed 6.4.5.5
Version: 7.3
Expected: run
Stdout: OK 13
Mutate: '\n' == 10
Into: '\r' == 10
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(char value) { return 1; }
    static int Tag(int value) { return 2; }
    static void Main()
    {
        Check('\'' == 39, "single-quote");
        Check('\"' == 34, "double-quote");
        Check('\\' == 92, "backslash");
        Check('\0' == 0, "null");
        Check('\a' == 7, "alert");
        Check('\b' == 8, "backspace");
        Check('\f' == 12, "form-feed");
        Check('\n' == 10, "line-feed");
        Check('\r' == 13, "carriage-return");
        Check('\t' == 9, "horizontal-tab");
        Check('\v' == 11, "vertical-tab");
        Check('Q' == 81, "unescaped-character");
        Check(Tag('Q') == 1, "char-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
