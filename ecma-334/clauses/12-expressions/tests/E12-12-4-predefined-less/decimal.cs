/*
Rules: E12-12-4-predefined-less; E12-12-4-numeric-values; E12-12-4-decimal-equivalence; E12-12-1-predefined-bool; E12-12-1-less-result
Authority: ECMA-334 7th ed 12.12.4
Version: 7.3
Expected: run
Stdout: OK 10
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static decimal A(decimal value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(-79228162514264337593543950335M) < A(79228162514264337593543950335M)) == true && Kind(A(-79228162514264337593543950335M) < A(79228162514264337593543950335M)) == 1, "case-0");
        Check((A(79228162514264337593543950335M) < A(-79228162514264337593543950335M)) == false && Kind(A(79228162514264337593543950335M) < A(-79228162514264337593543950335M)) == 1, "case-1");
        Check((A(-79228162514264337593543950335M) < A(-79228162514264337593543950335M)) == false && Kind(A(-79228162514264337593543950335M) < A(-79228162514264337593543950335M)) == 1, "case-2");
        Check((A(79228162514264337593543950335M) < A(79228162514264337593543950335M)) == false && Kind(A(79228162514264337593543950335M) < A(79228162514264337593543950335M)) == 1, "case-3");
        Check((A(19M) < A(4M)) == false && Kind(A(19M) < A(4M)) == 1, "case-4");
        Check((A(4M) < A(19M)) == true && Kind(A(4M) < A(19M)) == 1, "case-5");
        Check((A(4M) < A(4M)) == false && Kind(A(4M) < A(4M)) == 1, "case-6");
        Check((A(-4M) < A(0M)) == true && Kind(A(-4M) < A(0M)) == 1, "case-7");
        Check((A(0M) < A(-4M)) == false && Kind(A(0M) < A(-4M)) == 1, "case-8");
        Check((A(2.00M) < A(2.0M)) == false, "case-9");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
