/*
Rules: E12-11-predefined-right; E12-11-count-int; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-right-unsigned-discard; E12-11-right-unsigned-direction; E12-11-right-unsigned-fill; E12-11-logical-right
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 4
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
        Check(checked(A(13U) >> B(2)) == 3U && unchecked(A(13U) >> B(2)) == 3U && Kind(A(13U) >> B(2)) == 1, "case-0");
        Check(checked(A(4294967295U) >> B(1)) == 2147483647U && unchecked(A(4294967295U) >> B(1)) == 2147483647U && Kind(A(4294967295U) >> B(1)) == 1, "case-1");
        Check(checked(A(0U) >> B(3)) == 0U && unchecked(A(0U) >> B(3)) == 0U && Kind(A(0U) >> B(3)) == 1, "case-2");
        Check(checked(A(0U) >> B(-1)) == 0U && unchecked(A(0U) >> B(-1)) == 0U && Kind(A(0U) >> B(-1)) == 1, "case-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
