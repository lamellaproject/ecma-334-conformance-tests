/*
Rules: E12-10-6-integer-predefined; E12-10-6-numeric-difference
Authority: ECMA-334 7th ed 12.10.6
Version: 7.3
Expected: run
Stdout: OK 6
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static long A(long value) { return value; }
    static int Kind(long value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(unchecked(A(19L) - A(4L)) == 15L && Kind(unchecked(A(19L) - A(4L))) == 1, "case-0");
        Check(unchecked(A(0L) - A(4L)) == -4L && Kind(unchecked(A(0L) - A(4L))) == 1, "case-1");
        Check(unchecked(A(3L) - A(7L)) == -4L && Kind(unchecked(A(3L) - A(7L))) == 1, "case-2");
        Check(unchecked(A(-19L) - A(4L)) == -23L && Kind(unchecked(A(-19L) - A(4L))) == 1, "case-3");
        Check(unchecked(A(19L) - A(-4L)) == 23L && Kind(unchecked(A(19L) - A(-4L))) == 1, "case-4");
        Check(unchecked(A(-19L) - A(-4L)) == -15L && Kind(unchecked(A(-19L) - A(-4L))) == 1, "case-5");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
