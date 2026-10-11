/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : uint { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(uint value) { return (E)value; }
    static uint A(uint value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(uint value) { return 2; }
    static void Main()
    {
        Check((uint)unchecked(V(19U) + A(4U)) == 23U && Kind(unchecked(V(19U) + A(4U))) == 1 && (uint)unchecked(A(4U) + V(19U)) == 23U && Kind(unchecked(A(4U) + V(19U))) == 1, "case-0");
        Check((uint)unchecked(V(0U) + A(1U)) == 1U && Kind(unchecked(V(0U) + A(1U))) == 1 && (uint)unchecked(A(1U) + V(0U)) == 1U && Kind(unchecked(A(1U) + V(0U))) == 1, "case-1");
        Check((uint)unchecked(V(4294967295U) + A(1U)) == 0U && Kind(unchecked(V(4294967295U) + A(1U))) == 1 && (uint)unchecked(A(1U) + V(4294967295U)) == 0U && Kind(unchecked(A(1U) + V(4294967295U))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
