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
    static int? A(int? value) { return value; }
    static int Kind(int? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(-2147483648) & A(2147483647)) == 0 && Kind(A(-2147483648) & A(2147483647)) == 1, "case-0");
        Check((A(23) & A(12)) == 4 && Kind(A(23) & A(12)) == 1, "case-1");
        Check((A(null) & A(12)) == null && Kind(A(null) & A(12)) == 1, "case-2");
        Check((A(23) & A(null)) == null && Kind(A(23) & A(null)) == 1, "case-3");
        Check((A(null) & A(null)) == null && Kind(A(null) & A(null)) == 1, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
