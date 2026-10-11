/*
Rules: E12-13-5-predefined-and; E12-13-5-value-domain; E12-13-5-and-true-true; E12-13-5-and-true-false; E12-13-5-and-true-null; E12-13-5-and-false-true; E12-13-5-and-false-false; E12-13-5-and-false-null; E12-13-5-and-null-true; E12-13-5-and-null-false; E12-13-5-and-null-null
Authority: ECMA-334 7th ed 12.13.5
Version: 7.3
Expected: run
Stdout: OK 9
Generated: clauses/12-expressions/generators/logical.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool? A(bool? value) { return value; }
    static int Kind(bool? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(true) & A(true)) == true && Kind(A(true) & A(true)) == 1, "case-0");
        Check((A(true) & A(false)) == false && Kind(A(true) & A(false)) == 1, "case-1");
        Check((A(true) & A(null)) == null && Kind(A(true) & A(null)) == 1, "case-2");
        Check((A(false) & A(true)) == false && Kind(A(false) & A(true)) == 1, "case-3");
        Check((A(false) & A(false)) == false && Kind(A(false) & A(false)) == 1, "case-4");
        Check((A(false) & A(null)) == false && Kind(A(false) & A(null)) == 1, "case-5");
        Check((A(null) & A(true)) == null && Kind(A(null) & A(true)) == 1, "case-6");
        Check((A(null) & A(false)) == false && Kind(A(null) & A(false)) == 1, "case-7");
        Check((A(null) & A(null)) == null && Kind(A(null) & A(null)) == 1, "case-8");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
