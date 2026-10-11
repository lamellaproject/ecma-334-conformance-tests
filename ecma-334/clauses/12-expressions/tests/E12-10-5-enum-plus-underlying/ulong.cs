/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : ulong { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(ulong value) { return (E)value; }
    static ulong A(ulong value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(ulong value) { return 2; }
    static void Main()
    {
        Check((ulong)unchecked(V(19UL) + A(4UL)) == 23UL && Kind(unchecked(V(19UL) + A(4UL))) == 1 && (ulong)unchecked(A(4UL) + V(19UL)) == 23UL && Kind(unchecked(A(4UL) + V(19UL))) == 1, "case-0");
        Check((ulong)unchecked(V(0UL) + A(1UL)) == 1UL && Kind(unchecked(V(0UL) + A(1UL))) == 1 && (ulong)unchecked(A(1UL) + V(0UL)) == 1UL && Kind(unchecked(A(1UL) + V(0UL))) == 1, "case-1");
        Check((ulong)unchecked(V(18446744073709551615UL) + A(1UL)) == 0UL && Kind(unchecked(V(18446744073709551615UL) + A(1UL))) == 1 && (ulong)unchecked(A(1UL) + V(18446744073709551615UL)) == 0UL && Kind(unchecked(A(1UL) + V(18446744073709551615UL))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
