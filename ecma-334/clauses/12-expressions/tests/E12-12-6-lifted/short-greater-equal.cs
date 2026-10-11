/*
Rules: E12-12-6-lifted
Authority: ECMA-334 7th ed 12.12.6
Version: 7.3
Expected: run
Stdout: OK 5
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;
enum E : short { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E? A(E? value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A((E)(4)) >= A((E)(19))) == false, "case-0");
        Check((A((E)(4)) >= A((E)(4))) == true, "case-1");
        Check((A(null) >= A((E)(4))) == false, "case-2");
        Check((A((E)(4)) >= A(null)) == false, "case-3");
        Check((A(null) >= A(null)) == false, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
