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
    static ulong? A(ulong? value) { return value; }
    static int Kind(ulong? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(A(19UL) / A(4UL) == 4UL && Kind(A(19UL) / A(4UL)) == 1, "case-0");
        Check(!(A(null) / A(4UL)).HasValue, "case-1");
        Check(!(A(19UL) / A(null)).HasValue, "case-2");
        Check(!(A(null) / A(null)).HasValue, "case-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
