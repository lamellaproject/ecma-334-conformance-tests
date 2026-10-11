/*
Rules: E6-4-5-3-grammar-integer-type-suffix-3; E6-4-5-3-l-type; E6-4-5-3-decimal-value; E6-4-5-3-grammar-integer-literal-1; E6-4-5-3-grammar-decimal-integer-literal-1
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 2
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
        Check(Tag(61L) == 3 && 61L == 61UL, "value-0");
        Check(Tag(9223372036854775808L) == 4 && 9223372036854775808L == 9223372036854775808UL, "value-1");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
