/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : ushort { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(ushort value) { return (E)value; }
    static ushort A(ushort value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(ushort value) { return 2; }
    static void Main()
    {
        Check((ushort)unchecked(V(19) + A(4)) == 23 && Kind(unchecked(V(19) + A(4))) == 1 && (ushort)unchecked(A(4) + V(19)) == 23 && Kind(unchecked(A(4) + V(19))) == 1, "case-0");
        Check((ushort)unchecked(V(0) + A(1)) == 1 && Kind(unchecked(V(0) + A(1))) == 1 && (ushort)unchecked(A(1) + V(0)) == 1 && Kind(unchecked(A(1) + V(0))) == 1, "case-1");
        Check((ushort)unchecked(V(65535) + A(1)) == 0 && Kind(unchecked(V(65535) + A(1))) == 1 && (ushort)unchecked(A(1) + V(65535)) == 0 && Kind(unchecked(A(1) + V(65535))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
