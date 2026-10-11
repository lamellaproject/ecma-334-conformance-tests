/*
Rules: E12-11-lifted
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/12-expressions/generators/shifts.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int? A(int? value) { return value; }
    static int? B(int? value) { return value; }
    static void Main()
    {
        Check(A(13) >> B(2) == 3, "case-0");
        Check(!(A(null) >> B(2)).HasValue, "case-1");
        Check(!(A(13) >> B(null)).HasValue, "case-2");
        Check(!(A(null) >> B(null)).HasValue, "case-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
