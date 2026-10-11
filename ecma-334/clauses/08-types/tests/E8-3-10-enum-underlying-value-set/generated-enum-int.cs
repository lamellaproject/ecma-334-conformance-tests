/*
Rules: E8-3-10-enum-underlying-value-set; E8-3-10-enum-underlying-type-required; E8-3-10-enum-unnamed-values; E8-3-10-enum-declaration-form; E8-3-1-value-type-categories; E8-3-1-nonnullable-form-enum; E8-3-1-enum-form-name; E8-3-3-enum-default
Authority: ECMA-334 7th ed 8.3.10
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
enum Code : int { Marker = 1 }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code low = (Code)(-2147483648); Code high = (Code)(2147483647); Code empty = new Code();
        Check((int)low == -2147483648 && (int)high == 2147483647, "enum-int-full-domain");
        Check(empty == (Code)0, "enum-int-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
