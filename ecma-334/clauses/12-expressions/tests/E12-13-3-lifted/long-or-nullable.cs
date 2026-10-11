/*
Rules: E12-13-3-lifted
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 5
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : long { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E? A(E? value) { return value; }
    static int Kind(E? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A((E)(-9223372036854775808L)) | A((E)(9223372036854775807L))) == (E)(-1L) && Kind(A((E)(-9223372036854775808L)) | A((E)(9223372036854775807L))) == 1, "case-0");
        Check((A((E)(23L)) | A((E)(12L))) == (E)(31L) && Kind(A((E)(23L)) | A((E)(12L))) == 1, "case-1");
        Check((A(null) | A((E)(12L))) == null && Kind(A(null) | A((E)(12L))) == 1, "case-2");
        Check((A((E)(23L)) | A(null)) == null && Kind(A((E)(23L)) | A(null)) == 1, "case-3");
        Check((A(null) | A(null)) == null && Kind(A(null) | A(null)) == 1, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
