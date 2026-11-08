/*
Rules: E12-14-1-ed3-nullable-conditional-and
Authority: ECMA-334 3rd ed 14.10.4
Version: ISO-2
Expected: run
Stdout: OK 4
Version-Witness: version-witnesses/E12-14-1-ed3-nullable-conditional-and/nonnull-operands.cs.part
Mutate: return Left() && Right();
Into: return Left() & Right();
*/
// ECMA-334 3rd ed 14.10.4, p. 213 (PDF p. 233).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static bool? leftValue, rightValue;
    static int leftCalls, rightCalls;
    static bool? Left() { leftCalls++; return leftValue; }
    static bool? Right() { rightCalls++; return rightValue; }
    static bool? Combine() { return Left() && Right(); }
    static void Verify(bool left, bool right, bool expected, int calls)
    {
        leftValue = left;
        rightValue = right;
        leftCalls = rightCalls = 0;
        bool? result = Combine();
        Check(result == expected && leftCalls == 1 && rightCalls == calls, "conditional-logical-result");
    }
    static int Main()
    {
        Verify(true, true, true, 1);
        Verify(true, false, false, 1);
        Verify(false, true, false, 0);
        Verify(false, false, false, 0);
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
