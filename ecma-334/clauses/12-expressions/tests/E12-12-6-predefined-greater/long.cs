/*
Rules: E12-12-6-predefined-greater; E12-12-6-underlying-comparison; E12-12-1-predefined-bool; E12-12-1-greater-result
Authority: ECMA-334 7th ed 12.12.6
Version: 7.3
Expected: run
Stdout: OK 9
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;
enum E : long { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A((E)(-9223372036854775808L)) > A((E)(9223372036854775807L))) == false && Kind(A((E)(-9223372036854775808L)) > A((E)(9223372036854775807L))) == 1, "case-0");
        Check((A((E)(9223372036854775807L)) > A((E)(-9223372036854775808L))) == true && Kind(A((E)(9223372036854775807L)) > A((E)(-9223372036854775808L))) == 1, "case-1");
        Check((A((E)(-9223372036854775808L)) > A((E)(-9223372036854775808L))) == false && Kind(A((E)(-9223372036854775808L)) > A((E)(-9223372036854775808L))) == 1, "case-2");
        Check((A((E)(9223372036854775807L)) > A((E)(9223372036854775807L))) == false && Kind(A((E)(9223372036854775807L)) > A((E)(9223372036854775807L))) == 1, "case-3");
        Check((A((E)(19L)) > A((E)(4L))) == true && Kind(A((E)(19L)) > A((E)(4L))) == 1, "case-4");
        Check((A((E)(4L)) > A((E)(19L))) == false && Kind(A((E)(4L)) > A((E)(19L))) == 1, "case-5");
        Check((A((E)(4L)) > A((E)(4L))) == false && Kind(A((E)(4L)) > A((E)(4L))) == 1, "case-6");
        Check((A((E)(-4L)) > A((E)(0L))) == false && Kind(A((E)(-4L)) > A((E)(0L))) == 1, "case-7");
        Check((A((E)(0L)) > A((E)(-4L))) == true && Kind(A((E)(0L)) > A((E)(-4L))) == 1, "case-8");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
