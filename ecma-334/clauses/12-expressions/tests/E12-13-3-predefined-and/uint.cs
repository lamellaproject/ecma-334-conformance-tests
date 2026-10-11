/*
Rules: E12-13-3-predefined-and; E12-13-3-underlying-operation
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 12
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : uint { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A((E)(0U)) & A((E)(4294967295U))) == (E)(0U) && Kind(checked(A((E)(0U)) & A((E)(4294967295U)))) == 1, "case-0");
        Check(checked(A((E)(4294967295U)) & A((E)(4294967295U))) == (E)(4294967295U) && Kind(checked(A((E)(4294967295U)) & A((E)(4294967295U)))) == 1, "case-1");
        Check(checked(A((E)(0U)) & A((E)(4294967295U))) == (E)(0U) && Kind(checked(A((E)(0U)) & A((E)(4294967295U)))) == 1, "case-2");
        Check(checked(A((E)(1431655765U)) & A((E)(2863311530U))) == (E)(0U) && Kind(checked(A((E)(1431655765U)) & A((E)(2863311530U)))) == 1, "case-3");
        Check(checked(A((E)(1431655765U)) & A((E)(1431655765U))) == (E)(1431655765U) && Kind(checked(A((E)(1431655765U)) & A((E)(1431655765U)))) == 1, "case-4");
        Check(checked(A((E)(23U)) & A((E)(12U))) == (E)(4U) && Kind(checked(A((E)(23U)) & A((E)(12U)))) == 1, "case-5");
        Check(unchecked(A((E)(0U)) & A((E)(4294967295U))) == (E)(0U) && Kind(unchecked(A((E)(0U)) & A((E)(4294967295U)))) == 1, "case-6");
        Check(unchecked(A((E)(4294967295U)) & A((E)(4294967295U))) == (E)(4294967295U) && Kind(unchecked(A((E)(4294967295U)) & A((E)(4294967295U)))) == 1, "case-7");
        Check(unchecked(A((E)(0U)) & A((E)(4294967295U))) == (E)(0U) && Kind(unchecked(A((E)(0U)) & A((E)(4294967295U)))) == 1, "case-8");
        Check(unchecked(A((E)(1431655765U)) & A((E)(2863311530U))) == (E)(0U) && Kind(unchecked(A((E)(1431655765U)) & A((E)(2863311530U)))) == 1, "case-9");
        Check(unchecked(A((E)(1431655765U)) & A((E)(1431655765U))) == (E)(1431655765U) && Kind(unchecked(A((E)(1431655765U)) & A((E)(1431655765U)))) == 1, "case-10");
        Check(unchecked(A((E)(23U)) & A((E)(12U))) == (E)(4U) && Kind(unchecked(A((E)(23U)) & A((E)(12U)))) == 1, "case-11");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
