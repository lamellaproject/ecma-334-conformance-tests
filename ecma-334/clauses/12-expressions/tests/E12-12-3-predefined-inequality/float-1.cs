/*
Rules: E12-12-3-predefined-inequality; E12-12-3-iec-comparison; E12-12-3-ordered-finite-values; E12-12-3-nan-inequality; E12-12-3-signed-zero-equality; E12-12-1-predefined-bool; E12-12-1-inequality-result
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
    static float A(uint bits) { return *(float*)&bits; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(0xFF7FFFFFU) != A(0x7F800000U)) == true && Kind(A(0xFF7FFFFFU) != A(0x7F800000U)) == 1, "case-0");
        Check((A(0xFF7FFFFFU) != A(0x7FC00000U)) == true && Kind(A(0xFF7FFFFFU) != A(0x7FC00000U)) == 1, "case-1");
        Check((A(0x80000001U) != A(0xFF800000U)) == true && Kind(A(0x80000001U) != A(0xFF800000U)) == 1, "case-2");
        Check((A(0x80000001U) != A(0xFF7FFFFFU)) == true && Kind(A(0x80000001U) != A(0xFF7FFFFFU)) == 1, "case-3");
        Check((A(0x80000001U) != A(0x80000001U)) == false && Kind(A(0x80000001U) != A(0x80000001U)) == 1, "case-4");
        Check((A(0x80000001U) != A(0x80000000U)) == true && Kind(A(0x80000001U) != A(0x80000000U)) == 1, "case-5");
        Check((A(0x80000001U) != A(0x00000000U)) == true && Kind(A(0x80000001U) != A(0x00000000U)) == 1, "case-6");
        Check((A(0x80000001U) != A(0x00000001U)) == true && Kind(A(0x80000001U) != A(0x00000001U)) == 1, "case-7");
        Check((A(0x80000001U) != A(0x7F7FFFFFU)) == true && Kind(A(0x80000001U) != A(0x7F7FFFFFU)) == 1, "case-8");
        Check((A(0x80000001U) != A(0x7F800000U)) == true && Kind(A(0x80000001U) != A(0x7F800000U)) == 1, "case-9");
        Check((A(0x80000001U) != A(0x7FC00000U)) == true && Kind(A(0x80000001U) != A(0x7FC00000U)) == 1, "case-10");
        Check((A(0x80000000U) != A(0xFF800000U)) == true && Kind(A(0x80000000U) != A(0xFF800000U)) == 1, "case-11");
        Check((A(0x80000000U) != A(0xFF7FFFFFU)) == true && Kind(A(0x80000000U) != A(0xFF7FFFFFU)) == 1, "case-12");
        Check((A(0x80000000U) != A(0x80000001U)) == true && Kind(A(0x80000000U) != A(0x80000001U)) == 1, "case-13");
        Check((A(0x80000000U) != A(0x80000000U)) == false && Kind(A(0x80000000U) != A(0x80000000U)) == 1, "case-14");
        Check((A(0x80000000U) != A(0x00000000U)) == false && Kind(A(0x80000000U) != A(0x00000000U)) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
