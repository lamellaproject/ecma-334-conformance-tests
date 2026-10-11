/*
Rules: E6-4-5-6-grammar-regular-string-literal-1; E6-4-5-6-grammar-string-literal-1; E6-4-5-6-grammar-regular-string-literal-character-1; E6-4-5-6-grammar-regular-string-literal-character-2; E6-4-5-6-grammar-regular-string-literal-character-3; E6-4-5-6-grammar-regular-string-literal-character-4; E6-4-5-6-grammar-single-regular-string-literal-character-1; E6-4-5-6-string-type; E6-4-5-1-grammar-literal-5; E6-4-2-escape-regular-strings
Authority: ECMA-334 7th ed 6.4.5.6
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: string text = "Q\t\x2F\u03BB";
Into: string text = "Q\r\x2F\u03BB";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(string value) { return 1; }
    static int Tag(object value) { return 2; }
    static void Main()
    {
        string text = "Q\t\x2F\u03BB";
        Check(text.Length == 4 && text[0] == 81, "ordinary-character");
        Check(text[1] == 9, "simple-escape");
        Check(text[2] == 47, "hex-escape");
        Check(text[3] == 955, "unicode-escape");
        Check("".Length == 0, "zero-characters");
        Check(Tag("plain") == 1, "string-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
