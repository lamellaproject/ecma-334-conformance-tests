/*
Rules: E12-12-2-predefined-inequality; E12-12-2-numeric-values; E12-12-1-predefined-bool; E12-12-1-inequality-result
Authority: ECMA-334 7th ed 12.12.2
Version: 7.3
Expected: run
Stdout: OK 9
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int A(int value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(-2147483648) != A(2147483647)) == true && Kind(A(-2147483648) != A(2147483647)) == 1, "case-0");
        Check((A(2147483647) != A(-2147483648)) == true && Kind(A(2147483647) != A(-2147483648)) == 1, "case-1");
        Check((A(-2147483648) != A(-2147483648)) == false && Kind(A(-2147483648) != A(-2147483648)) == 1, "case-2");
        Check((A(2147483647) != A(2147483647)) == false && Kind(A(2147483647) != A(2147483647)) == 1, "case-3");
        Check((A(19) != A(4)) == true && Kind(A(19) != A(4)) == 1, "case-4");
        Check((A(4) != A(19)) == true && Kind(A(4) != A(19)) == 1, "case-5");
        Check((A(4) != A(4)) == false && Kind(A(4) != A(4)) == 1, "case-6");
        Check((A(-4) != A(0)) == true && Kind(A(-4) != A(0)) == 1, "case-7");
        Check((A(0) != A(-4)) == true && Kind(A(0) != A(-4)) == 1, "case-8");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
