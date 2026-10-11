/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : long { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(long value) { return (E)value; }
    static long A(long value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(long value) { return 2; }
    static void Main()
    {
        Check((long)unchecked(V(19L) + A(4L)) == 23L && Kind(unchecked(V(19L) + A(4L))) == 1 && (long)unchecked(A(4L) + V(19L)) == 23L && Kind(unchecked(A(4L) + V(19L))) == 1, "case-0");
        Check((long)unchecked(V(-9223372036854775808L) + A(1L)) == -9223372036854775807L && Kind(unchecked(V(-9223372036854775808L) + A(1L))) == 1 && (long)unchecked(A(1L) + V(-9223372036854775808L)) == -9223372036854775807L && Kind(unchecked(A(1L) + V(-9223372036854775808L))) == 1, "case-1");
        Check((long)unchecked(V(9223372036854775807L) + A(1L)) == -9223372036854775808L && Kind(unchecked(V(9223372036854775807L) + A(1L))) == 1 && (long)unchecked(A(1L) + V(9223372036854775807L)) == -9223372036854775808L && Kind(unchecked(A(1L) + V(9223372036854775807L))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
