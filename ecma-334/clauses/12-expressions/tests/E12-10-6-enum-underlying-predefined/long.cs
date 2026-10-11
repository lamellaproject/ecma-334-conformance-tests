/*
Rules: E12-10-6-enum-underlying-predefined; E12-10-6-enum-underlying-value; E12-10-6-enum-underlying-result-type
Authority: ECMA-334 7th ed 12.10.6
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
        Check((long)unchecked(V(19L) - A(4L)) == 15L && Kind(unchecked(V(19L) - A(4L))) == 1, "case-0");
        Check((long)unchecked(V(-9223372036854775808L) - A(1L)) == 9223372036854775807L && Kind(unchecked(V(-9223372036854775808L) - A(1L))) == 1, "case-1");
        Check((long)unchecked(V(9223372036854775807L) - A(1L)) == 9223372036854775806L && Kind(unchecked(V(9223372036854775807L) - A(1L))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
