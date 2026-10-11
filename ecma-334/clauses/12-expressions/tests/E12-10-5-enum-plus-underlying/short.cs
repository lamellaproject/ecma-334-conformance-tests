/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : short { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(short value) { return (E)value; }
    static short A(short value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(short value) { return 2; }
    static void Main()
    {
        Check((short)unchecked(V(19) + A(4)) == 23 && Kind(unchecked(V(19) + A(4))) == 1 && (short)unchecked(A(4) + V(19)) == 23 && Kind(unchecked(A(4) + V(19))) == 1, "case-0");
        Check((short)unchecked(V(-32768) + A(1)) == -32767 && Kind(unchecked(V(-32768) + A(1))) == 1 && (short)unchecked(A(1) + V(-32768)) == -32767 && Kind(unchecked(A(1) + V(-32768))) == 1, "case-1");
        Check((short)unchecked(V(32767) + A(1)) == -32768 && Kind(unchecked(V(32767) + A(1))) == 1 && (short)unchecked(A(1) + V(32767)) == -32768 && Kind(unchecked(A(1) + V(32767))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
