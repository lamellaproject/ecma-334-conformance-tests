/*
Rules: E12-11-predefined-right; E12-11-count-long; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-right-signed-discard; E12-11-right-signed-direction; E12-11-right-nonnegative-fill; E12-11-right-negative-fill; E12-11-arithmetic-right
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
        Check(checked(A(-9223372036854775795L) >> B(-65)) == -1L && unchecked(A(-9223372036854775795L) >> B(-65)) == -1L && Kind(A(-9223372036854775795L) >> B(-65)) == 1, "case-0");
        Check(checked(A(-9223372036854775795L) >> B(-64)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) >> B(-64)) == -9223372036854775795L && Kind(A(-9223372036854775795L) >> B(-64)) == 1, "case-1");
        Check(checked(A(-9223372036854775795L) >> B(-33)) == -4294967296L && unchecked(A(-9223372036854775795L) >> B(-33)) == -4294967296L && Kind(A(-9223372036854775795L) >> B(-33)) == 1, "case-2");
        Check(checked(A(-9223372036854775795L) >> B(-32)) == -2147483648L && unchecked(A(-9223372036854775795L) >> B(-32)) == -2147483648L && Kind(A(-9223372036854775795L) >> B(-32)) == 1, "case-3");
        Check(checked(A(-9223372036854775795L) >> B(-1)) == -1L && unchecked(A(-9223372036854775795L) >> B(-1)) == -1L && Kind(A(-9223372036854775795L) >> B(-1)) == 1, "case-4");
        Check(checked(A(-9223372036854775795L) >> B(0)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) >> B(0)) == -9223372036854775795L && Kind(A(-9223372036854775795L) >> B(0)) == 1, "case-5");
        Check(checked(A(-9223372036854775795L) >> B(1)) == -4611686018427387898L && unchecked(A(-9223372036854775795L) >> B(1)) == -4611686018427387898L && Kind(A(-9223372036854775795L) >> B(1)) == 1, "case-6");
        Check(checked(A(-9223372036854775795L) >> B(31)) == -4294967296L && unchecked(A(-9223372036854775795L) >> B(31)) == -4294967296L && Kind(A(-9223372036854775795L) >> B(31)) == 1, "case-7");
        Check(checked(A(-9223372036854775795L) >> B(32)) == -2147483648L && unchecked(A(-9223372036854775795L) >> B(32)) == -2147483648L && Kind(A(-9223372036854775795L) >> B(32)) == 1, "case-8");
        Check(checked(A(-9223372036854775795L) >> B(33)) == -1073741824L && unchecked(A(-9223372036854775795L) >> B(33)) == -1073741824L && Kind(A(-9223372036854775795L) >> B(33)) == 1, "case-9");
        Check(checked(A(-9223372036854775795L) >> B(63)) == -1L && unchecked(A(-9223372036854775795L) >> B(63)) == -1L && Kind(A(-9223372036854775795L) >> B(63)) == 1, "case-10");
        Check(checked(A(-9223372036854775795L) >> B(64)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) >> B(64)) == -9223372036854775795L && Kind(A(-9223372036854775795L) >> B(64)) == 1, "case-11");
        Check(checked(A(-9223372036854775795L) >> B(65)) == -4611686018427387898L && unchecked(A(-9223372036854775795L) >> B(65)) == -4611686018427387898L && Kind(A(-9223372036854775795L) >> B(65)) == 1, "case-12");
        Check(checked(A(-9223372036854775795L) >> B(127)) == -1L && unchecked(A(-9223372036854775795L) >> B(127)) == -1L && Kind(A(-9223372036854775795L) >> B(127)) == 1, "case-13");
        Check(checked(A(-9223372036854775795L) >> B(2147483647)) == -1L && unchecked(A(-9223372036854775795L) >> B(2147483647)) == -1L && Kind(A(-9223372036854775795L) >> B(2147483647)) == 1, "case-14");
        Check(checked(A(-9223372036854775795L) >> B(-2147483648)) == -9223372036854775795L && unchecked(A(-9223372036854775795L) >> B(-2147483648)) == -9223372036854775795L && Kind(A(-9223372036854775795L) >> B(-2147483648)) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
