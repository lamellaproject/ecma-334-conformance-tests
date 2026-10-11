/*
Rules: E12-11-predefined-left; E12-11-count-long; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-left-direction; E12-11-left-discard; E12-11-left-fill
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 16
Generated: clauses/12-expressions/generators/shifts.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static long A(long value) { return value; }
    static int B(int value) { return value; }
    static int Kind(long value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(-9223372036854775795L) << B(-65)) == -9223372036854775808L && unchecked(A(-9223372036854775795L) << B(-65)) == -9223372036854775808L && Kind(A(-9223372036854775795L) << B(-65)) == 1, "case-0");
        Check(checked(A(-9223372036854775795L) << B(-64)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) << B(-64)) == -9223372036854775795L && Kind(A(-9223372036854775795L) << B(-64)) == 1, "case-1");
        Check(checked(A(-9223372036854775795L) << B(-33)) == 27917287424L && unchecked(A(-9223372036854775795L) << B(-33)) == 27917287424L && Kind(A(-9223372036854775795L) << B(-33)) == 1, "case-2");
        Check(checked(A(-9223372036854775795L) << B(-32)) == 55834574848L && unchecked(A(-9223372036854775795L) << B(-32)) == 55834574848L && Kind(A(-9223372036854775795L) << B(-32)) == 1, "case-3");
        Check(checked(A(-9223372036854775795L) << B(-1)) == -9223372036854775808L && unchecked(A(-9223372036854775795L) << B(-1)) == -9223372036854775808L && Kind(A(-9223372036854775795L) << B(-1)) == 1, "case-4");
        Check(checked(A(-9223372036854775795L) << B(0)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) << B(0)) == -9223372036854775795L && Kind(A(-9223372036854775795L) << B(0)) == 1, "case-5");
        Check(checked(A(-9223372036854775795L) << B(1)) == 26L && unchecked(A(-9223372036854775795L) << B(1)) == 26L && Kind(A(-9223372036854775795L) << B(1)) == 1, "case-6");
        Check(checked(A(-9223372036854775795L) << B(31)) == 27917287424L && unchecked(A(-9223372036854775795L) << B(31)) == 27917287424L && Kind(A(-9223372036854775795L) << B(31)) == 1, "case-7");
        Check(checked(A(-9223372036854775795L) << B(32)) == 55834574848L && unchecked(A(-9223372036854775795L) << B(32)) == 55834574848L && Kind(A(-9223372036854775795L) << B(32)) == 1, "case-8");
        Check(checked(A(-9223372036854775795L) << B(33)) == 111669149696L && unchecked(A(-9223372036854775795L) << B(33)) == 111669149696L && Kind(A(-9223372036854775795L) << B(33)) == 1, "case-9");
        Check(checked(A(-9223372036854775795L) << B(63)) == -9223372036854775808L && unchecked(A(-9223372036854775795L) << B(63)) == -9223372036854775808L && Kind(A(-9223372036854775795L) << B(63)) == 1, "case-10");
        Check(checked(A(-9223372036854775795L) << B(64)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) << B(64)) == -9223372036854775795L && Kind(A(-9223372036854775795L) << B(64)) == 1, "case-11");
        Check(checked(A(-9223372036854775795L) << B(65)) == 26L && unchecked(A(-9223372036854775795L) << B(65)) == 26L && Kind(A(-9223372036854775795L) << B(65)) == 1, "case-12");
        Check(checked(A(-9223372036854775795L) << B(127)) == -9223372036854775808L && unchecked(A(-9223372036854775795L) << B(127)) == -9223372036854775808L && Kind(A(-9223372036854775795L) << B(127)) == 1, "case-13");
        Check(checked(A(-9223372036854775795L) << B(2147483647)) == -9223372036854775808L && unchecked(A(-9223372036854775795L) << B(2147483647)) == -9223372036854775808L && Kind(A(-9223372036854775795L) << B(2147483647)) == 1, "case-14");
        Check(checked(A(-9223372036854775795L) << B(-2147483648)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) << B(-2147483648)) == -9223372036854775795L && Kind(A(-9223372036854775795L) << B(-2147483648)) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
