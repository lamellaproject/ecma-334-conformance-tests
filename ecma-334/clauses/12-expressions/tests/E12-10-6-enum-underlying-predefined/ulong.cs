/*
Rules: E12-10-6-enum-underlying-predefined; E12-10-6-enum-underlying-value; E12-10-6-enum-underlying-result-type
Authority: ECMA-334 7th ed 12.10.6
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
        Check((ulong)unchecked(V(19UL) - A(4UL)) == 15UL && Kind(unchecked(V(19UL) - A(4UL))) == 1, "case-0");
        Check((ulong)unchecked(V(0UL) - A(1UL)) == 18446744073709551615UL && Kind(unchecked(V(0UL) - A(1UL))) == 1, "case-1");
        Check((ulong)unchecked(V(18446744073709551615UL) - A(1UL)) == 18446744073709551614UL && Kind(unchecked(V(18446744073709551615UL) - A(1UL))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
