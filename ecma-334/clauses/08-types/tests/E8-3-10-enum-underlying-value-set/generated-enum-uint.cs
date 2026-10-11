/*
Rules: E8-3-10-enum-underlying-value-set; E8-3-10-enum-underlying-type-required; E8-3-10-enum-unnamed-values; E8-3-10-enum-declaration-form; E8-3-1-value-type-categories; E8-3-1-nonnullable-form-enum; E8-3-1-enum-form-name; E8-3-3-enum-default
Authority: ECMA-334 7th ed 8.3.10
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
enum Code : uint { Marker = 1 }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code low = (Code)(0U); Code high = (Code)(4294967295U); Code empty = new Code();
        Check((uint)low == 0U && (uint)high == 4294967295U, "enum-uint-full-domain");
        Check(empty == (Code)0, "enum-uint-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
