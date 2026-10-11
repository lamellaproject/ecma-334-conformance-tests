/*
Rules: E12-13-3-lifted
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 5
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : uint { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E? A(E? value) { return value; }
    static int Kind(E? value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A((E)(0U)) & A((E)(4294967295U))) == (E)(0U) && Kind(A((E)(0U)) & A((E)(4294967295U))) == 1, "case-0");
        Check((A((E)(23U)) & A((E)(12U))) == (E)(4U) && Kind(A((E)(23U)) & A((E)(12U))) == 1, "case-1");
        Check((A(null) & A((E)(12U))) == null && Kind(A(null) & A((E)(12U))) == 1, "case-2");
        Check((A((E)(23U)) & A(null)) == null && Kind(A((E)(23U)) & A(null)) == 1, "case-3");
        Check((A(null) & A(null)) == null && Kind(A(null) & A(null)) == 1, "case-4");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
