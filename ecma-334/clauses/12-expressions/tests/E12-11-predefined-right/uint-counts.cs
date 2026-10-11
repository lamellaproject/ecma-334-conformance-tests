/*
Rules: E12-11-predefined-right; E12-11-count-int; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-right-unsigned-discard; E12-11-right-unsigned-direction; E12-11-right-unsigned-fill; E12-11-logical-right
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
    static uint A(uint value) { return value; }
    static int B(int value) { return value; }
    static int Kind(uint value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(4294967283U) >> B(-65)) == 1U && unchecked(A(4294967283U) >> B(-65)) == 1U && Kind(A(4294967283U) >> B(-65)) == 1, "case-0");
        Check(checked(A(4294967283U) >> B(-64)) == 4294967283U && unchecked(A(4294967283U) >> B(-64)) == 4294967283U && Kind(A(4294967283U) >> B(-64)) == 1, "case-1");
        Check(checked(A(4294967283U) >> B(-33)) == 1U && unchecked(A(4294967283U) >> B(-33)) == 1U && Kind(A(4294967283U) >> B(-33)) == 1, "case-2");
        Check(checked(A(4294967283U) >> B(-32)) == 4294967283U && unchecked(A(4294967283U) >> B(-32)) == 4294967283U && Kind(A(4294967283U) >> B(-32)) == 1, "case-3");
        Check(checked(A(4294967283U) >> B(-1)) == 1U && unchecked(A(4294967283U) >> B(-1)) == 1U && Kind(A(4294967283U) >> B(-1)) == 1, "case-4");
        Check(checked(A(4294967283U) >> B(0)) == 4294967283U && unchecked(A(4294967283U) >> B(0)) == 4294967283U && Kind(A(4294967283U) >> B(0)) == 1, "case-5");
        Check(checked(A(4294967283U) >> B(1)) == 2147483641U && unchecked(A(4294967283U) >> B(1)) == 2147483641U && Kind(A(4294967283U) >> B(1)) == 1, "case-6");
        Check(checked(A(4294967283U) >> B(31)) == 1U && unchecked(A(4294967283U) >> B(31)) == 1U && Kind(A(4294967283U) >> B(31)) == 1, "case-7");
        Check(checked(A(4294967283U) >> B(32)) == 4294967283U && unchecked(A(4294967283U) >> B(32)) == 4294967283U && Kind(A(4294967283U) >> B(32)) == 1, "case-8");
        Check(checked(A(4294967283U) >> B(33)) == 2147483641U && unchecked(A(4294967283U) >> B(33)) == 2147483641U && Kind(A(4294967283U) >> B(33)) == 1, "case-9");
        Check(checked(A(4294967283U) >> B(63)) == 1U && unchecked(A(4294967283U) >> B(63)) == 1U && Kind(A(4294967283U) >> B(63)) == 1, "case-10");
        Check(checked(A(4294967283U) >> B(64)) == 4294967283U && unchecked(A(4294967283U) >> B(64)) == 4294967283U && Kind(A(4294967283U) >> B(64)) == 1, "case-11");
        Check(checked(A(4294967283U) >> B(65)) == 2147483641U && unchecked(A(4294967283U) >> B(65)) == 2147483641U && Kind(A(4294967283U) >> B(65)) == 1, "case-12");
        Check(checked(A(4294967283U) >> B(127)) == 1U && unchecked(A(4294967283U) >> B(127)) == 1U && Kind(A(4294967283U) >> B(127)) == 1, "case-13");
        Check(checked(A(4294967283U) >> B(2147483647)) == 1U && unchecked(A(4294967283U) >> B(2147483647)) == 1U && Kind(A(4294967283U) >> B(2147483647)) == 1, "case-14");
        Check(checked(A(4294967283U) >> B(-2147483648)) == 4294967283U && unchecked(A(4294967283U) >> B(-2147483648)) == 4294967283U && Kind(A(4294967283U) >> B(-2147483648)) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
