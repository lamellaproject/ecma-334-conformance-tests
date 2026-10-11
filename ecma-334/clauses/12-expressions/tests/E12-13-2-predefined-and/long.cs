/*
Rules: E12-13-2-predefined-and; E12-13-2-bitwise-and; E12-13-2-no-overflow
Authority: ECMA-334 7th ed 12.13.2
Version: 7.3
Expected: run
Stdout: OK 16
Generated: clauses/12-expressions/generators/logical.py
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
        Check(checked(A(-9223372036854775808L) & A(9223372036854775807L)) == 0L && Kind(checked(A(-9223372036854775808L) & A(9223372036854775807L))) == 1, "case-0");
        Check(checked(A(9223372036854775807L) & A(9223372036854775807L)) == 9223372036854775807L && Kind(checked(A(9223372036854775807L) & A(9223372036854775807L))) == 1, "case-1");
        Check(checked(A(0L) & A(9223372036854775807L)) == 0L && Kind(checked(A(0L) & A(9223372036854775807L))) == 1, "case-2");
        Check(checked(A(6148914691236517205L) & A(-6148914691236517206L)) == 0L && Kind(checked(A(6148914691236517205L) & A(-6148914691236517206L))) == 1, "case-3");
        Check(checked(A(6148914691236517205L) & A(6148914691236517205L)) == 6148914691236517205L && Kind(checked(A(6148914691236517205L) & A(6148914691236517205L))) == 1, "case-4");
        Check(checked(A(23L) & A(12L)) == 4L && Kind(checked(A(23L) & A(12L))) == 1, "case-5");
        Check(checked(A(-1L) & A(6148914691236517205L)) == 6148914691236517205L && Kind(checked(A(-1L) & A(6148914691236517205L))) == 1, "case-6");
        Check(checked(A(-19L) & A(-4L)) == -20L && Kind(checked(A(-19L) & A(-4L))) == 1, "case-7");
        Check(unchecked(A(-9223372036854775808L) & A(9223372036854775807L)) == 0L && Kind(unchecked(A(-9223372036854775808L) & A(9223372036854775807L))) == 1, "case-8");
        Check(unchecked(A(9223372036854775807L) & A(9223372036854775807L)) == 9223372036854775807L && Kind(unchecked(A(9223372036854775807L) & A(9223372036854775807L))) == 1, "case-9");
        Check(unchecked(A(0L) & A(9223372036854775807L)) == 0L && Kind(unchecked(A(0L) & A(9223372036854775807L))) == 1, "case-10");
        Check(unchecked(A(6148914691236517205L) & A(-6148914691236517206L)) == 0L && Kind(unchecked(A(6148914691236517205L) & A(-6148914691236517206L))) == 1, "case-11");
        Check(unchecked(A(6148914691236517205L) & A(6148914691236517205L)) == 6148914691236517205L && Kind(unchecked(A(6148914691236517205L) & A(6148914691236517205L))) == 1, "case-12");
        Check(unchecked(A(23L) & A(12L)) == 4L && Kind(unchecked(A(23L) & A(12L))) == 1, "case-13");
        Check(unchecked(A(-1L) & A(6148914691236517205L)) == 6148914691236517205L && Kind(unchecked(A(-1L) & A(6148914691236517205L))) == 1, "case-14");
        Check(unchecked(A(-19L) & A(-4L)) == -20L && Kind(unchecked(A(-19L) & A(-4L))) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
