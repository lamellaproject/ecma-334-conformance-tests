/*
Rules: E8-3-5-alias-decimal; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-3-decimal-default; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-1-numeric-form-decimal
Authority: ECMA-334 7th ed 8.3.5
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.Decimal named = 3.25m; decimal same = named; decimal empty = new decimal();
        decimal* address = &same;
        Check(same == 3.25m, "decimal-keyword-alias");
        Check(empty == 0, "decimal-default-value");
        Check(!empty.Equals(same), "decimal-aliased-members");
        Check(*address == same, "decimal-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
