/*
Rules: E12-12-6-predefined-greater-equal; E12-12-6-underlying-comparison; E12-12-1-predefined-bool; E12-12-1-greater-equal-result
Authority: ECMA-334 7th ed 12.12.6
Version: 7.3
Expected: run
Stdout: OK 9
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;
enum E : short { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A((E)(-32768)) >= A((E)(32767))) == false && Kind(A((E)(-32768)) >= A((E)(32767))) == 1, "case-0");
        Check((A((E)(32767)) >= A((E)(-32768))) == true && Kind(A((E)(32767)) >= A((E)(-32768))) == 1, "case-1");
        Check((A((E)(-32768)) >= A((E)(-32768))) == true && Kind(A((E)(-32768)) >= A((E)(-32768))) == 1, "case-2");
        Check((A((E)(32767)) >= A((E)(32767))) == true && Kind(A((E)(32767)) >= A((E)(32767))) == 1, "case-3");
        Check((A((E)(19)) >= A((E)(4))) == true && Kind(A((E)(19)) >= A((E)(4))) == 1, "case-4");
        Check((A((E)(4)) >= A((E)(19))) == false && Kind(A((E)(4)) >= A((E)(19))) == 1, "case-5");
        Check((A((E)(4)) >= A((E)(4))) == true && Kind(A((E)(4)) >= A((E)(4))) == 1, "case-6");
        Check((A((E)(-4)) >= A((E)(0))) == false && Kind(A((E)(-4)) >= A((E)(0))) == 1, "case-7");
        Check((A((E)(0)) >= A((E)(-4))) == true && Kind(A((E)(0)) >= A((E)(-4))) == 1, "case-8");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
