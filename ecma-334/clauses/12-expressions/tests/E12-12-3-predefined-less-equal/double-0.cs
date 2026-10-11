/*
Rules: E12-12-3-predefined-less-equal; E12-12-3-iec-comparison; E12-12-3-ordered-finite-values; E12-12-3-nan-less-equal; E12-12-1-predefined-bool; E12-12-1-less-equal-result
Authority: ECMA-334 7th ed 12.12.3
Version: 7.3
Expected: run
Stdout: OK 16
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
        Check((A(0xFFF0000000000000UL) <= A(0xFFF0000000000000UL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0xFFF0000000000000UL)) == 1, "case-0");
        Check((A(0xFFF0000000000000UL) <= A(0xFFEFFFFFFFFFFFFFUL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0xFFEFFFFFFFFFFFFFUL)) == 1, "case-1");
        Check((A(0xFFF0000000000000UL) <= A(0x8000000000000001UL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0x8000000000000001UL)) == 1, "case-2");
        Check((A(0xFFF0000000000000UL) <= A(0x8000000000000000UL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0x8000000000000000UL)) == 1, "case-3");
        Check((A(0xFFF0000000000000UL) <= A(0x0000000000000000UL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0x0000000000000000UL)) == 1, "case-4");
        Check((A(0xFFF0000000000000UL) <= A(0x0000000000000001UL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0x0000000000000001UL)) == 1, "case-5");
        Check((A(0xFFF0000000000000UL) <= A(0x7FEFFFFFFFFFFFFFUL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0x7FEFFFFFFFFFFFFFUL)) == 1, "case-6");
        Check((A(0xFFF0000000000000UL) <= A(0x7FF0000000000000UL)) == true && Kind(A(0xFFF0000000000000UL) <= A(0x7FF0000000000000UL)) == 1, "case-7");
        Check((A(0xFFF0000000000000UL) <= A(0x7FF8000000000000UL)) == false && Kind(A(0xFFF0000000000000UL) <= A(0x7FF8000000000000UL)) == 1, "case-8");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0xFFF0000000000000UL)) == false && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0xFFF0000000000000UL)) == 1, "case-9");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0xFFEFFFFFFFFFFFFFUL)) == true && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0xFFEFFFFFFFFFFFFFUL)) == 1, "case-10");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0x8000000000000001UL)) == true && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0x8000000000000001UL)) == 1, "case-11");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0x8000000000000000UL)) == true && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0x8000000000000000UL)) == 1, "case-12");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0x0000000000000000UL)) == true && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0x0000000000000000UL)) == 1, "case-13");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0x0000000000000001UL)) == true && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0x0000000000000001UL)) == 1, "case-14");
        Check((A(0xFFEFFFFFFFFFFFFFUL) <= A(0x7FEFFFFFFFFFFFFFUL)) == true && Kind(A(0xFFEFFFFFFFFFFFFFUL) <= A(0x7FEFFFFFFFFFFFFFUL)) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
