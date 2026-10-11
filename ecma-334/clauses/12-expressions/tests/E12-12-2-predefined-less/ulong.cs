/*
Rules: E12-12-2-predefined-less; E12-12-2-numeric-values; E12-12-1-predefined-bool; E12-12-1-less-result
Authority: ECMA-334 7th ed 12.12.2
Version: 7.3
Expected: run
Stdout: OK 7
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ulong A(ulong value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(0UL) < A(18446744073709551615UL)) == true && Kind(A(0UL) < A(18446744073709551615UL)) == 1, "case-0");
        Check((A(18446744073709551615UL) < A(0UL)) == false && Kind(A(18446744073709551615UL) < A(0UL)) == 1, "case-1");
        Check((A(0UL) < A(0UL)) == false && Kind(A(0UL) < A(0UL)) == 1, "case-2");
        Check((A(18446744073709551615UL) < A(18446744073709551615UL)) == false && Kind(A(18446744073709551615UL) < A(18446744073709551615UL)) == 1, "case-3");
        Check((A(19UL) < A(4UL)) == false && Kind(A(19UL) < A(4UL)) == 1, "case-4");
        Check((A(4UL) < A(19UL)) == true && Kind(A(4UL) < A(19UL)) == 1, "case-5");
        Check((A(4UL) < A(4UL)) == false && Kind(A(4UL) < A(4UL)) == 1, "case-6");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
