/*
Rules: E12-12-5-lifted
Authority: ECMA-334 7th ed 12.12.5
Version: 7.3
Expected: run
Stdout: OK 5
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool? A(bool? value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(false) == A(true)) == false, "case-0");
        Check((A(true) == A(true)) == true, "case-1");
        Check((A(null) == A(true)) == false, "case-2");
        Check((A(true) == A(null)) == false, "case-3");
        Check((A(null) == A(null)) == true, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
