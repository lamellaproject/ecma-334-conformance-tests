/*
Rules: E12-10-5-enum-plus-underlying; E12-10-5-underlying-plus-enum; E12-10-5-enum-value
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : int { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(int value) { return (E)value; }
    static int A(int value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check((int)unchecked(V(19) + A(4)) == 23 && Kind(unchecked(V(19) + A(4))) == 1 && (int)unchecked(A(4) + V(19)) == 23 && Kind(unchecked(A(4) + V(19))) == 1, "case-0");
        Check((int)unchecked(V(-2147483648) + A(1)) == -2147483647 && Kind(unchecked(V(-2147483648) + A(1))) == 1 && (int)unchecked(A(1) + V(-2147483648)) == -2147483647 && Kind(unchecked(A(1) + V(-2147483648))) == 1, "case-1");
        Check((int)unchecked(V(2147483647) + A(1)) == -2147483648 && Kind(unchecked(V(2147483647) + A(1))) == 1 && (int)unchecked(A(1) + V(2147483647)) == -2147483648 && Kind(unchecked(A(1) + V(2147483647))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
