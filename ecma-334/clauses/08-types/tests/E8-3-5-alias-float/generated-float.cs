/*
Rules: E8-3-5-alias-float; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-3-float-default; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-1-floating-form-float; E8-3-1-numeric-form-floating
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
        System.Single named = 3.25f; float same = named; float empty = new float();
        float* address = &same;
        Check(same == 3.25f, "float-keyword-alias");
        Check(empty == 0, "float-default-value");
        Check(!empty.Equals(same), "float-aliased-members");
        Check(*address == same, "float-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
