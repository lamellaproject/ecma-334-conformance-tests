/*
Rules: E12-10-2-integer-unchecked-truncation; E12-10-2-integer-unchecked-no-report
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 2
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
        Check(unchecked(A(9223372036854775807L) * A(2L)) == -2L, "case-0");
        Check(unchecked(A(-9223372036854775808L) * A(-1L)) == -9223372036854775808L, "case-1");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
