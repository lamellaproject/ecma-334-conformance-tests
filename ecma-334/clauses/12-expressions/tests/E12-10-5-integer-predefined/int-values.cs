/*
Rules: E12-10-5-integer-predefined; E12-10-5-numeric-sum
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 6
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int A(int value) { return value; }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(unchecked(A(19) + A(4)) == 23 && Kind(unchecked(A(19) + A(4))) == 1, "case-0");
        Check(unchecked(A(0) + A(4)) == 4 && Kind(unchecked(A(0) + A(4))) == 1, "case-1");
        Check(unchecked(A(3) + A(7)) == 10 && Kind(unchecked(A(3) + A(7))) == 1, "case-2");
        Check(unchecked(A(-19) + A(4)) == -15 && Kind(unchecked(A(-19) + A(4))) == 1, "case-3");
        Check(unchecked(A(19) + A(-4)) == 15 && Kind(unchecked(A(19) + A(-4))) == 1, "case-4");
        Check(unchecked(A(-19) + A(-4)) == -23 && Kind(unchecked(A(-19) + A(-4))) == 1, "case-5");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
