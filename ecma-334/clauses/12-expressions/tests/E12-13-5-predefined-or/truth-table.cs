/*
Rules: E12-13-5-predefined-or; E12-13-5-value-domain; E12-13-5-or-true-true; E12-13-5-or-true-false; E12-13-5-or-true-null; E12-13-5-or-false-true; E12-13-5-or-false-false; E12-13-5-or-false-null; E12-13-5-or-null-true; E12-13-5-or-null-false; E12-13-5-or-null-null
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
        Check((A(true) | A(true)) == true && Kind(A(true) | A(true)) == 1, "case-0");
        Check((A(true) | A(false)) == true && Kind(A(true) | A(false)) == 1, "case-1");
        Check((A(true) | A(null)) == true && Kind(A(true) | A(null)) == 1, "case-2");
        Check((A(false) | A(true)) == true && Kind(A(false) | A(true)) == 1, "case-3");
        Check((A(false) | A(false)) == false && Kind(A(false) | A(false)) == 1, "case-4");
        Check((A(false) | A(null)) == null && Kind(A(false) | A(null)) == 1, "case-5");
        Check((A(null) | A(true)) == true && Kind(A(null) | A(true)) == 1, "case-6");
        Check((A(null) | A(false)) == null && Kind(A(null) | A(false)) == 1, "case-7");
        Check((A(null) | A(null)) == null && Kind(A(null) | A(null)) == 1, "case-8");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
