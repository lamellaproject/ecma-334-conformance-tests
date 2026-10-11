/*
Rules: E8-3-5-alias-double; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-3-double-default; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-1-floating-form-double; E8-3-1-numeric-form-floating
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
        System.Double named = 3.25d; double same = named; double empty = new double();
        double* address = &same;
        Check(same == 3.25d, "double-keyword-alias");
        Check(empty == 0, "double-default-value");
        Check(!empty.Equals(same), "double-aliased-members");
        Check(*address == same, "double-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
