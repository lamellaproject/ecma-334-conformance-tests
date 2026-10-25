/*
Rules: E12-10-3-ed1-unchecked-division-wrap
Authority: ECMA-334 1st ed 14.7.2
Version: ISO-1
Expected: run
Stdout: OK 4
Version-Witness: tests/E12-10-3-ed1-unchecked-division-wrap/minimum-unchecked-division.witness.cs.part
Mutate: static int Divide(int left, int right) { return unchecked(left / right); }
Into: static int Divide(int left, int right) { return unchecked(left + right); }
*/
// ECMA-334 1st ed 14.7.2, p. 158 (PDF p. 172), lines 23-25. Unchecked nonconstant int or
// long division of its minimum value by minus one returns the left operand without
// reporting overflow or throwing an exception.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Divide(int left, int right) { return unchecked(left / right); }
    static long DivideWide(long left, long right) { return unchecked(left / right); }
    static bool MatchesInt(int left, int right, int expected)
    {
        try { return Divide(left, right) == expected; }
        catch (ArithmeticException) { return false; }
    }
    static bool MatchesLong(long left, long right, long expected)
    {
        try { return DivideWide(left, right) == expected; }
        catch (ArithmeticException) { return false; }
    }
    static int Main()
    {
        Check(MatchesInt(Int32.MinValue, -1, Int32.MinValue), "int-wrap");
        Check(MatchesLong(Int64.MinValue, -1, Int64.MinValue), "long-wrap");
        Check(MatchesInt(10, -2, -5), "int-control");
        Check(MatchesLong(10, -2, -5), "long-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
