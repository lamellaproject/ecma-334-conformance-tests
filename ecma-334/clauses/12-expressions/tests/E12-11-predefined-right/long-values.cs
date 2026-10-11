/*
Rules: E12-11-predefined-right; E12-11-count-long; E12-11-zero-count; E12-11-no-overflow; E12-11-context-independent; E12-11-right-signed-discard; E12-11-right-signed-direction; E12-11-right-nonnegative-fill; E12-11-right-negative-fill; E12-11-arithmetic-right
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
    static long A(long value) { return value; }
    static int B(int value) { return value; }
    static int Kind(long value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(13L) >> B(2)) == 3L && unchecked(A(13L) >> B(2)) == 3L && Kind(A(13L) >> B(2)) == 1, "case-0");
        Check(checked(A(9223372036854775807L) >> B(1)) == 4611686018427387903L && unchecked(A(9223372036854775807L) >> B(1)) == 4611686018427387903L && Kind(A(9223372036854775807L) >> B(1)) == 1, "case-1");
        Check(checked(A(-9223372036854775808L) >> B(3)) == -1152921504606846976L && unchecked(A(-9223372036854775808L) >> B(3)) == -1152921504606846976L && Kind(A(-9223372036854775808L) >> B(3)) == 1, "case-2");
        Check(checked(A(0L) >> B(-1)) == 0L && unchecked(A(0L) >> B(-1)) == 0L && Kind(A(0L) >> B(-1)) == 1, "case-3");
        Check(checked(A(-7L) >> B(2)) == -2L && unchecked(A(-7L) >> B(2)) == -2L && Kind(A(-7L) >> B(2)) == 1, "case-4");
        Check(checked(A(-1L) >> B(1)) == -1L && unchecked(A(-1L) >> B(1)) == -1L && Kind(A(-1L) >> B(1)) == 1, "case-5");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
