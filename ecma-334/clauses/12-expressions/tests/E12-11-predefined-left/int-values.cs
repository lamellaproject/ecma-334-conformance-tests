/*
Rules: E12-11-predefined-left; E12-11-count-int; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-left-direction; E12-11-left-discard; E12-11-left-fill
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 6
Generated: clauses/12-expressions/generators/shifts.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int A(int value) { return value; }
    static int B(int value) { return value; }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(13) << B(2)) == 52 && unchecked(A(13) << B(2)) == 52 && Kind(A(13) << B(2)) == 1, "case-0");
        Check(checked(A(2147483647) << B(1)) == -2 && unchecked(A(2147483647) << B(1)) == -2 && Kind(A(2147483647) << B(1)) == 1, "case-1");
        Check(checked(A(-2147483648) << B(3)) == 0 && unchecked(A(-2147483648) << B(3)) == 0 && Kind(A(-2147483648) << B(3)) == 1, "case-2");
        Check(checked(A(0) << B(-1)) == 0 && unchecked(A(0) << B(-1)) == 0 && Kind(A(0) << B(-1)) == 1, "case-3");
        Check(checked(A(-7) << B(2)) == -28 && unchecked(A(-7) << B(2)) == -28 && Kind(A(-7) << B(2)) == 1, "case-4");
        Check(checked(A(-1) << B(1)) == -2 && unchecked(A(-1) << B(1)) == -2 && Kind(A(-1) << B(1)) == 1, "case-5");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
