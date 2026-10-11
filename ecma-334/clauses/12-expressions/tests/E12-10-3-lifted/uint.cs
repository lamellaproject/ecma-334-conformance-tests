/*
Rules: E12-10-3-lifted
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static uint? A(uint? value) { return value; }
    static int Kind(uint? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(A(19U) / A(4U) == 4U && Kind(A(19U) / A(4U)) == 1, "case-0");
        Check(!(A(null) / A(4U)).HasValue, "case-1");
        Check(!(A(19U) / A(null)).HasValue, "case-2");
        Check(!(A(null) / A(null)).HasValue, "case-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
