/*
Rules: E12-11-predefined-right; E12-11-count-long; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-right-unsigned-discard; E12-11-right-unsigned-direction; E12-11-right-unsigned-fill; E12-11-logical-right
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
    static ulong A(ulong value) { return value; }
    static int B(int value) { return value; }
    static int Kind(ulong value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(18446744073709551603UL) >> B(-65)) == 1UL && unchecked(A(18446744073709551603UL) >> B(-65)) == 1UL && Kind(A(18446744073709551603UL) >> B(-65)) == 1, "case-0");
        Check(checked(A(18446744073709551603UL) >> B(-64)) == 18446744073709551603UL && unchecked(A(18446744073709551603UL) >> B(-64)) == 18446744073709551603UL && Kind(A(18446744073709551603UL) >> B(-64)) == 1, "case-1");
        Check(checked(A(18446744073709551603UL) >> B(-33)) == 8589934591UL && unchecked(A(18446744073709551603UL) >> B(-33)) == 8589934591UL && Kind(A(18446744073709551603UL) >> B(-33)) == 1, "case-2");
        Check(checked(A(18446744073709551603UL) >> B(-32)) == 4294967295UL && unchecked(A(18446744073709551603UL) >> B(-32)) == 4294967295UL && Kind(A(18446744073709551603UL) >> B(-32)) == 1, "case-3");
        Check(checked(A(18446744073709551603UL) >> B(-1)) == 1UL && unchecked(A(18446744073709551603UL) >> B(-1)) == 1UL && Kind(A(18446744073709551603UL) >> B(-1)) == 1, "case-4");
        Check(checked(A(18446744073709551603UL) >> B(0)) == 18446744073709551603UL && unchecked(A(18446744073709551603UL) >> B(0)) == 18446744073709551603UL && Kind(A(18446744073709551603UL) >> B(0)) == 1, "case-5");
        Check(checked(A(18446744073709551603UL) >> B(1)) == 9223372036854775801UL && unchecked(A(18446744073709551603UL) >> B(1)) == 9223372036854775801UL && Kind(A(18446744073709551603UL) >> B(1)) == 1, "case-6");
        Check(checked(A(18446744073709551603UL) >> B(31)) == 8589934591UL && unchecked(A(18446744073709551603UL) >> B(31)) == 8589934591UL && Kind(A(18446744073709551603UL) >> B(31)) == 1, "case-7");
        Check(checked(A(18446744073709551603UL) >> B(32)) == 4294967295UL && unchecked(A(18446744073709551603UL) >> B(32)) == 4294967295UL && Kind(A(18446744073709551603UL) >> B(32)) == 1, "case-8");
        Check(checked(A(18446744073709551603UL) >> B(33)) == 2147483647UL && unchecked(A(18446744073709551603UL) >> B(33)) == 2147483647UL && Kind(A(18446744073709551603UL) >> B(33)) == 1, "case-9");
        Check(checked(A(18446744073709551603UL) >> B(63)) == 1UL && unchecked(A(18446744073709551603UL) >> B(63)) == 1UL && Kind(A(18446744073709551603UL) >> B(63)) == 1, "case-10");
        Check(checked(A(18446744073709551603UL) >> B(64)) == 18446744073709551603UL && unchecked(A(18446744073709551603UL) >> B(64)) == 18446744073709551603UL && Kind(A(18446744073709551603UL) >> B(64)) == 1, "case-11");
        Check(checked(A(18446744073709551603UL) >> B(65)) == 9223372036854775801UL && unchecked(A(18446744073709551603UL) >> B(65)) == 9223372036854775801UL && Kind(A(18446744073709551603UL) >> B(65)) == 1, "case-12");
        Check(checked(A(18446744073709551603UL) >> B(127)) == 1UL && unchecked(A(18446744073709551603UL) >> B(127)) == 1UL && Kind(A(18446744073709551603UL) >> B(127)) == 1, "case-13");
        Check(checked(A(18446744073709551603UL) >> B(2147483647)) == 1UL && unchecked(A(18446744073709551603UL) >> B(2147483647)) == 1UL && Kind(A(18446744073709551603UL) >> B(2147483647)) == 1, "case-14");
        Check(checked(A(18446744073709551603UL) >> B(-2147483648)) == 18446744073709551603UL && unchecked(A(18446744073709551603UL) >> B(-2147483648)) == 18446744073709551603UL && Kind(A(18446744073709551603UL) >> B(-2147483648)) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
