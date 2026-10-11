/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : sbyte { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(sbyte value) { return (E)value; }
    static sbyte A(sbyte value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(sbyte value) { return 2; }
    static void Main()
    {
        Check((sbyte)unchecked(V(19) + A(4)) == 23 && Kind(unchecked(V(19) + A(4))) == 1 && (sbyte)unchecked(A(4) + V(19)) == 23 && Kind(unchecked(A(4) + V(19))) == 1, "case-0");
        Check((sbyte)unchecked(V(-128) + A(1)) == -127 && Kind(unchecked(V(-128) + A(1))) == 1 && (sbyte)unchecked(A(1) + V(-128)) == -127 && Kind(unchecked(A(1) + V(-128))) == 1, "case-1");
        Check((sbyte)unchecked(V(127) + A(1)) == -128 && Kind(unchecked(V(127) + A(1))) == 1 && (sbyte)unchecked(A(1) + V(127)) == -128 && Kind(unchecked(A(1) + V(127))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
