/*
Rules: E12-10-3-integer-predefined; E12-10-3-quotient; E12-10-3-integer-rounding; E12-10-3-integer-same-sign
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static uint A(uint value) { return value; }
    static int Kind(uint value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(unchecked(A(19U) / A(4U)) == 4U && Kind(unchecked(A(19U) / A(4U))) == 1, "case-0");
        Check(unchecked(A(0U) / A(4U)) == 0U && Kind(unchecked(A(0U) / A(4U))) == 1, "case-1");
        Check(unchecked(A(3U) / A(7U)) == 0U && Kind(unchecked(A(3U) / A(7U))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
