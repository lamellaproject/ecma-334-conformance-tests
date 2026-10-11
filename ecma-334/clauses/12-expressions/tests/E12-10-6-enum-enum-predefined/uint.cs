/*
Rules: E12-10-6-enum-enum-predefined; E12-10-6-enum-enum-value; E12-10-6-enum-enum-result-type
Authority: ECMA-334 7th ed 12.10.6
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
        Check((uint)unchecked(V(19U) - V(4U)) == 15U && Kind(unchecked(V(19U) - V(4U))) == 2, "case-0");
        Check((uint)unchecked(V(0U) - V(1U)) == 4294967295U && Kind(unchecked(V(0U) - V(1U))) == 2, "case-1");
        Check((uint)unchecked(V(4294967295U) - V(1U)) == 4294967294U && Kind(unchecked(V(4294967295U) - V(1U))) == 2, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
