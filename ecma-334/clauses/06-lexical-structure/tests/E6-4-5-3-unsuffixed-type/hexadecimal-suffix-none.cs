/*
Rules: E6-4-5-3-unsuffixed-type; E6-4-5-3-hexadecimal-value; E6-4-5-3-grammar-integer-literal-2; E6-4-5-3-grammar-hexadecimal-integer-literal-1
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/06-lexical-structure/generators/integer-suffixes.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(int value) { return 1; }
    static int Tag(uint value) { return 2; }
    static int Tag(long value) { return 3; }
    static int Tag(ulong value) { return 4; }
    static void Main()
    {
        Check(Tag(0x3D) == 1 && 0x3D == 61UL, "value-0");
        Check(Tag(0x80000000) == 2 && 0x80000000 == 2147483648UL, "value-1");
        Check(Tag(0x100000000) == 3 && 0x100000000 == 4294967296UL, "value-2");
        Check(Tag(0x8000000000000000) == 4 && 0x8000000000000000 == 9223372036854775808UL, "value-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
