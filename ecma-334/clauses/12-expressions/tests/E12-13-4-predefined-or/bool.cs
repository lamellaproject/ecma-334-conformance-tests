/*
Rules: E12-13-4-predefined-or; E12-13-4-or-result
Authority: ECMA-334 7th ed 12.13.4
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/12-expressions/generators/logical.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool A(bool value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(false) | A(false)) == false && Kind(A(false) | A(false)) == 1, "case-0");
        Check((A(false) | A(true)) == true && Kind(A(false) | A(true)) == 1, "case-1");
        Check((A(true) | A(false)) == true && Kind(A(true) | A(false)) == 1, "case-2");
        Check((A(true) | A(true)) == true && Kind(A(true) | A(true)) == 1, "case-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
