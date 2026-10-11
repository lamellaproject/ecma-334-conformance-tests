/*
Rules: E12-13-2-lifted
Authority: ECMA-334 7th ed 12.13.2
Version: 7.3
Expected: run
Stdout: OK 5
Generated: clauses/12-expressions/generators/logical.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ulong? A(ulong? value) { return value; }
    static int Kind(ulong? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(0UL) & A(18446744073709551615UL)) == 0UL && Kind(A(0UL) & A(18446744073709551615UL)) == 1, "case-0");
        Check((A(23UL) & A(12UL)) == 4UL && Kind(A(23UL) & A(12UL)) == 1, "case-1");
        Check((A(null) & A(12UL)) == null && Kind(A(null) & A(12UL)) == 1, "case-2");
        Check((A(23UL) & A(null)) == null && Kind(A(23UL) & A(null)) == 1, "case-3");
        Check((A(null) & A(null)) == null && Kind(A(null) & A(null)) == 1, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
