/*
Rules: E12-12-2-lifted
Authority: ECMA-334 7th ed 12.12.2
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
    static int? A(int? value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(4) <= A(19)) == true, "case-0");
        Check((A(4) <= A(4)) == true, "case-1");
        Check((A(null) <= A(4)) == false, "case-2");
        Check((A(4) <= A(null)) == false, "case-3");
        Check((A(null) <= A(null)) == false, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
