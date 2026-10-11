/*
Rules: E8-3-5-alias-bool; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-3-bool-default; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-1-simple-form-bool; E8-3-9-bool-values
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
        System.Boolean named = true; bool same = named; bool empty = new bool();
        bool* address = &same;
        Check(same == true, "bool-keyword-alias");
        Check(empty == false, "bool-default-value");
        Check(!empty.Equals(same), "bool-aliased-members");
        Check(*address == same, "bool-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
