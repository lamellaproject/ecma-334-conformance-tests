/*
Rules: E12-12-3-predefined-inequality; E12-12-3-iec-comparison; E12-12-3-ordered-finite-values; E12-12-3-nan-inequality; E12-12-1-predefined-bool; E12-12-1-inequality-result
Authority: ECMA-334 7th ed 12.12.3
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static double A(ulong bits) { return *(double*)&bits; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(0x7FF8000000000000UL) != A(0x7FF8000000000000UL)) == true && Kind(A(0x7FF8000000000000UL) != A(0x7FF8000000000000UL)) == 1, "case-0");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
