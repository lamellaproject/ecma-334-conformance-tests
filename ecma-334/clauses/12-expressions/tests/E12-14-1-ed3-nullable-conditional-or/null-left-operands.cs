/*
Rules: E12-14-1-ed3-nullable-conditional-or
Authority: ECMA-334 3rd ed 14.10.4
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E12-14-1-ed3-nullable-conditional-or/null-left-operands.cs.part
Mutate: Left() || Right()
Into: Left() || rightValue
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool? rightValue;
    static int leftCalls, rightCalls;
    static bool? Left() { leftCalls++; return null; }
    static bool? Right() { rightCalls++; return rightValue; }
    static bool? Combine() { return Left() || Right(); }
    static void Verify(bool? right, bool? expected)
    {
        rightValue = right;
        leftCalls = rightCalls = 0;
        bool? result = Combine();
        Check(result == expected && leftCalls == 1 && rightCalls == 1, "null-left-or");
    }
    static int Main()
    {
        Verify(true, true);
        Verify(false, null);
        Verify(null, null);
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
