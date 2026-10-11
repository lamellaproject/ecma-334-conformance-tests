/*
Rules: E12-10-6-enum-underlying-predefined; E12-10-6-enum-underlying-value; E12-10-6-enum-underlying-result-type
Authority: ECMA-334 7th ed 12.10.6
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
        Check((int)unchecked(V(19) - A(4)) == 15 && Kind(unchecked(V(19) - A(4))) == 1, "case-0");
        Check((int)unchecked(V(-2147483648) - A(1)) == 2147483647 && Kind(unchecked(V(-2147483648) - A(1))) == 1, "case-1");
        Check((int)unchecked(V(2147483647) - A(1)) == 2147483646 && Kind(unchecked(V(2147483647) - A(1))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
