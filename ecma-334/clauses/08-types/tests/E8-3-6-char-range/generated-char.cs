/*
Rules: E8-3-6-char-range; E8-3-6-char-format; E8-3-5-alias-char; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-char; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-char-default; E8-3-6-char-unicode; E8-3-6-char-integral-classification; E8-3-6-char-constant-spelling
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: run
Stdout: OK 8
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char low = '\u0000'; char high = '\uffff'; char empty = new char();
        System.Char alias = 'Q'; char same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(char); i++) if (zeros[i] != 0) allZeros = false;
        char* address = &same;
        int promoted = high + 1; char castLiteral = (char)0x51;
        Check(sizeof(char) == 2, "char-storage-width");
        Check(low == '\u0000' && high == '\uffff', "char-inclusive-endpoints");
        Check(same == 'Q', "char-keyword-alias");
        Check(empty == (char)0, "char-default-zero");
        Check(empty.CompareTo(same) < 0, "char-aliased-members");
        Check(allZeros, "char-default-bits");
        Check(*address == same, "char-unmanaged-address");
        Check(promoted == 65536 && castLiteral == same, "char-integral-and-literal-cast");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
