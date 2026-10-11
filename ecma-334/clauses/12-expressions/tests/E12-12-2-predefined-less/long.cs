/*
Rules: E12-12-2-predefined-less; E12-12-2-numeric-values; E12-12-1-predefined-bool; E12-12-1-less-result
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
    static long A(long value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(-9223372036854775808L) < A(9223372036854775807L)) == true && Kind(A(-9223372036854775808L) < A(9223372036854775807L)) == 1, "case-0");
        Check((A(9223372036854775807L) < A(-9223372036854775808L)) == false && Kind(A(9223372036854775807L) < A(-9223372036854775808L)) == 1, "case-1");
        Check((A(-9223372036854775808L) < A(-9223372036854775808L)) == false && Kind(A(-9223372036854775808L) < A(-9223372036854775808L)) == 1, "case-2");
        Check((A(9223372036854775807L) < A(9223372036854775807L)) == false && Kind(A(9223372036854775807L) < A(9223372036854775807L)) == 1, "case-3");
        Check((A(19L) < A(4L)) == false && Kind(A(19L) < A(4L)) == 1, "case-4");
        Check((A(4L) < A(19L)) == true && Kind(A(4L) < A(19L)) == 1, "case-5");
        Check((A(4L) < A(4L)) == false && Kind(A(4L) < A(4L)) == 1, "case-6");
        Check((A(-4L) < A(0L)) == true && Kind(A(-4L) < A(0L)) == 1, "case-7");
        Check((A(0L) < A(-4L)) == false && Kind(A(0L) < A(-4L)) == 1, "case-8");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
