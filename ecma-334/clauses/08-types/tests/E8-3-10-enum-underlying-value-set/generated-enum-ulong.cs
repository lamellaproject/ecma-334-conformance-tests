/*
Rules: E8-3-10-enum-underlying-value-set; E8-3-10-enum-underlying-type-required; E8-3-10-enum-unnamed-values; E8-3-10-enum-declaration-form; E8-3-1-value-type-categories; E8-3-1-nonnullable-form-enum; E8-3-1-enum-form-name; E8-3-3-enum-default
Authority: ECMA-334 7th ed 8.3.10
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
enum Code : ulong { Marker = 1 }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code low = (Code)(0UL); Code high = (Code)(18446744073709551615UL); Code empty = new Code();
        Check((ulong)low == 0UL && (ulong)high == 18446744073709551615UL, "enum-ulong-full-domain");
        Check(empty == (Code)0, "enum-ulong-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
