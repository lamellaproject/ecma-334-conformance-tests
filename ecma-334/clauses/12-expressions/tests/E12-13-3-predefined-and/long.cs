/*
Rules: E12-13-3-predefined-and; E12-13-3-underlying-operation
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 16
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : long { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A((E)(-9223372036854775808L)) & A((E)(9223372036854775807L))) == (E)(0L) && Kind(checked(A((E)(-9223372036854775808L)) & A((E)(9223372036854775807L)))) == 1, "case-0");
        Check(checked(A((E)(9223372036854775807L)) & A((E)(9223372036854775807L))) == (E)(9223372036854775807L) && Kind(checked(A((E)(9223372036854775807L)) & A((E)(9223372036854775807L)))) == 1, "case-1");
        Check(checked(A((E)(0L)) & A((E)(9223372036854775807L))) == (E)(0L) && Kind(checked(A((E)(0L)) & A((E)(9223372036854775807L)))) == 1, "case-2");
        Check(checked(A((E)(6148914691236517205L)) & A((E)(-6148914691236517206L))) == (E)(0L) && Kind(checked(A((E)(6148914691236517205L)) & A((E)(-6148914691236517206L)))) == 1, "case-3");
        Check(checked(A((E)(6148914691236517205L)) & A((E)(6148914691236517205L))) == (E)(6148914691236517205L) && Kind(checked(A((E)(6148914691236517205L)) & A((E)(6148914691236517205L)))) == 1, "case-4");
        Check(checked(A((E)(23L)) & A((E)(12L))) == (E)(4L) && Kind(checked(A((E)(23L)) & A((E)(12L)))) == 1, "case-5");
        Check(checked(A((E)(-1L)) & A((E)(6148914691236517205L))) == (E)(6148914691236517205L) && Kind(checked(A((E)(-1L)) & A((E)(6148914691236517205L)))) == 1, "case-6");
        Check(checked(A((E)(-19L)) & A((E)(-4L))) == (E)(-20L) && Kind(checked(A((E)(-19L)) & A((E)(-4L)))) == 1, "case-7");
        Check(unchecked(A((E)(-9223372036854775808L)) & A((E)(9223372036854775807L))) == (E)(0L) && Kind(unchecked(A((E)(-9223372036854775808L)) & A((E)(9223372036854775807L)))) == 1, "case-8");
        Check(unchecked(A((E)(9223372036854775807L)) & A((E)(9223372036854775807L))) == (E)(9223372036854775807L) && Kind(unchecked(A((E)(9223372036854775807L)) & A((E)(9223372036854775807L)))) == 1, "case-9");
        Check(unchecked(A((E)(0L)) & A((E)(9223372036854775807L))) == (E)(0L) && Kind(unchecked(A((E)(0L)) & A((E)(9223372036854775807L)))) == 1, "case-10");
        Check(unchecked(A((E)(6148914691236517205L)) & A((E)(-6148914691236517206L))) == (E)(0L) && Kind(unchecked(A((E)(6148914691236517205L)) & A((E)(-6148914691236517206L)))) == 1, "case-11");
        Check(unchecked(A((E)(6148914691236517205L)) & A((E)(6148914691236517205L))) == (E)(6148914691236517205L) && Kind(unchecked(A((E)(6148914691236517205L)) & A((E)(6148914691236517205L)))) == 1, "case-12");
        Check(unchecked(A((E)(23L)) & A((E)(12L))) == (E)(4L) && Kind(unchecked(A((E)(23L)) & A((E)(12L)))) == 1, "case-13");
        Check(unchecked(A((E)(-1L)) & A((E)(6148914691236517205L))) == (E)(6148914691236517205L) && Kind(unchecked(A((E)(-1L)) & A((E)(6148914691236517205L)))) == 1, "case-14");
        Check(unchecked(A((E)(-19L)) & A((E)(-4L))) == (E)(-20L) && Kind(unchecked(A((E)(-19L)) & A((E)(-4L)))) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
